#region Imports

using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Parsers.Gremlin
{

    /// <summary>
    /// Gremlin filter parser for pipeline.
    /// </summary>
    public class FilterParserPipeline : IFilterParser
    {

        #region Public methods

        /// <summary>
        /// Determines if the parser is capable of handling a given filter type.
        /// </summary>
        /// <param name="filter">Filter to parse.</param>
        /// <returns>True if the parser can handle the given filter type.</returns>
        public bool IsHandledType(IFilter filter)
        {
            return filter is FilterPipeline;
        }

        /// <summary>
        /// Parses a filter into its filter string equivalent.
        /// </summary>
        /// <typeparam name="TFilterParserConfiguration">The type of the filter parser configuration.</typeparam>
        /// <param name="filterParserService">Filter parser service.</param>
        /// <param name="filter">Filter to parse.</param>
        /// <returns>Filter string.</returns>
        public string ParseFilter<TFilterParserConfiguration>(IFilterService<TFilterParserConfiguration> filterParserService, IFilter filter) where TFilterParserConfiguration : IFilterServiceConfiguration, new()
        {
            if (!IsHandledType(filter))
                throw new ArgumentException($"Invalid filter type provided to parser.", nameof(filter));

            FilterPipeline pipeline = (filter as FilterPipeline)!; // null hint...

            var baseEnumerator = pipeline.Filters.GetEnumerator();
            var currentLogicalOperator = pipeline.Filters.First(x => x is FilterLogicalOperator) as FilterLogicalOperator
                ?? throw new Exception("Logical operator not found within pipeline; perhaps an invalid pipeline definition.");

            string result = GetFilterString(filterParserService, ref baseEnumerator, currentLogicalOperator);

            return result;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Gets the filter string for a given filter pipeline.
        /// </summary>
        /// <typeparam name="TFilterParserConfiguration">The type of the filter parser configuration.</typeparam>
        /// <param name="filterParserService">Filter parser service.</param>
        /// <param name="filterEnumerator">Enumerator for the filter pipeline.</param>
        /// <param name="currentOperator">Current logical operator being processed.</param>
        /// <param name="innerStatement">Inner statement to append to the filter string.</param>
        /// <returns>The filter string for the given filter pipeline.</returns>
        private string GetFilterString<TFilterParserConfiguration>(IFilterService<TFilterParserConfiguration> filterParserService, ref List<IFilter>.Enumerator filterEnumerator, FilterLogicalOperator currentOperator, string? innerStatement = null) where TFilterParserConfiguration : IFilterServiceConfiguration, new()
        {
            // get the filter string of the current operator being processed...
            var logicalOperatorString = filterParserService.GetFilterString(currentOperator);

            // begin the logical operator string...
            string result = logicalOperatorString + "(";

            // if we have an inner statement, append it now...
            if (!string.IsNullOrEmpty(innerStatement))
            {
                result += innerStatement + ",";
            }

            while (filterEnumerator.MoveNext())
            {
                var i = filterEnumerator.Current;

                // collect the predicates sequentially which match this operator...
                if (i is FilterLogicalOperator)
                {
                    // ensure the logical operator is consistent with the one being handled... if it is not, we need to
                    //  begin a new logical operation... this involves closing the existing logical statement, and using it as a
                    //  parameter within the new statement...
                    var logicalOperator = (i as FilterLogicalOperator)!; // null hint...

                    if (currentOperator.Operator != logicalOperator.Operator)
                    {
                        // trim the additional comma from the end...
                        result = result.TrimEnd(',');
                        result += ")";

                        result = GetFilterString(filterParserService, ref filterEnumerator, logicalOperator, result) + ",";
                    }
                }
                else
                {
                    result += filterParserService.GetFilterString(i) + ",";
                }
            }

            // trim the additional comma from the end...
            result = result.TrimEnd(',');

            if (string.IsNullOrEmpty(innerStatement))
                result += ")";

            return result;
        }

        #endregion

    }

}
