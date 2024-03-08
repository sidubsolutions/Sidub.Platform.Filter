#region Imports

using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Parsers.MySql
{

    /// <summary>
    /// MySQL filter parser for logical operator.
    /// </summary>
    public class FilterParserLogicalOperator : IFilterParser
    {

        #region Public methods

        /// <summary>
        /// Determines if the parser is capable of handling a given filter type.
        /// </summary>
        /// <param name="filter">Filter to parse.</param>
        /// <returns>True if the parser can handle the given filter type.</returns>
        public bool IsHandledType(IFilter filter)
        {
            return filter is FilterLogicalOperator;
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

            FilterLogicalOperator logicalOperator = (filter as FilterLogicalOperator)!; // null hint...

            string result = logicalOperator.Operator switch
            {
                LogicalOperator.And => "and",
                LogicalOperator.Or => "or",
                _ => throw new Exception($"Unhandled logical operator type '{logicalOperator.Operator}'."),
            };

            return result;
        }

        #endregion

    }

}
