#region Imports

#endregion

namespace Sidub.Platform.Filter.Parsers.Gremlin
{

    /// <summary>
    /// Gremlin filter value parser for Guid values.
    /// </summary>
    public class FilterValueParserGuid : IFilterValueParser
    {

        #region Public methods

        /// <summary>
        /// Determines if the parser is capable of handling a given filter value type.
        /// </summary>
        /// <param name="filterValue">The filter value to parse.</param>
        /// <returns>True if the parser can handle the given filter value type, otherwise false.</returns>
        public bool IsHandledType(object filterValue)
        {
            return filterValue is Guid;
        }

        /// <summary>
        /// Parses a filter value to its string equivalent.
        /// </summary>
        /// <param name="value">The filter value to parse.</param>
        /// <returns>The string equivalent of the filter value.</returns>
        public string ParseFilterValue(object value)
        {
            Guid guidValue = (Guid)value;

            return $"'{guidValue:D}'";
        }

        #endregion

    }

}
