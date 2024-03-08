#region Imports

#endregion

namespace Sidub.Platform.Filter.Parsers.OData
{

    /// <summary>
    /// OData filter value parser for string values.
    /// </summary>
    public class FilterValueParserGuid : IFilterValueParser
    {

        #region Public methods

        /// <summary>
        /// Determines if the parser is capable of handling a given filter value type.
        /// </summary>
        /// <param name="filterValue">Filter value to parse.</param>
        /// <returns>True if the parser can handle the given filter value type.</returns>
        public bool IsHandledType(object filterValue)
        {
            return filterValue is Guid;
        }

        /// <summary>
        /// Parses a filter value to the filter string equivalent.
        /// </summary>
        /// <param name="value">Filter value to parse.</param>
        /// <returns>Filter string equivalent of the filter value.</returns>
        public string ParseFilterValue(object value)
        {
            var guidValue = (Guid)value;
            return $"'{guidValue.ToString("D")}'";
        }

        #endregion

    }

}
