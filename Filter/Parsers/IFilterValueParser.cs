namespace Sidub.Platform.Filter.Parsers
{

    /// <summary>
    /// Filter value parser interface. Provides functionality for parsing a filter value to
    /// a filter string, for example converting a string or integer to the filter string representation.
    /// </summary>
    public interface IFilterValueParser
    {

        #region Interface methods

        /// <summary>
        /// Parses a filter value to the filter string equivalent.
        /// </summary>
        /// <param name="value">Filter value to parse.</param>
        /// <returns>Filter string equivalent of the filter value.</returns>
        string ParseFilterValue(object value);

        /// <summary>
        /// Determines if the parser is capable of handling a given filter value type.
        /// </summary>
        /// <param name="filterValue">Filter value to parse.</param>
        /// <returns>True if the parser can handle the given filter value type.</returns>
        bool IsHandledType(object filterValue);

        #endregion

    }

}
