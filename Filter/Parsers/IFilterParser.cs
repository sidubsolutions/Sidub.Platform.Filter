#region Imports

using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Parsers
{

    /// <summary>
    /// Filter component parser interface.
    /// </summary>
    public interface IFilterParser
    {

        #region Interface methods

        /// <summary>
        /// Parses a filter into its filter string equivalent.
        /// </summary>
        /// <typeparam name="TFilterParserConfiguration">The type of the filter parser configuration.</typeparam>
        /// <param name="filterParserService">The filter parser service.</param>
        /// <param name="filter">The filter to parse.</param>
        /// <returns>The filter string.</returns>
        string ParseFilter<TFilterParserConfiguration>(IFilterService<TFilterParserConfiguration> filterParserService, IFilter filter) where TFilterParserConfiguration : IFilterServiceConfiguration, new();

        /// <summary>
        /// Determines if the parser is capable of handling a given filter type.
        /// </summary>
        /// <param name="filter">The filter to parse.</param>
        /// <returns>True if the parser can handle the given filter type; otherwise, false.</returns>
        bool IsHandledType(IFilter filter);

        #endregion

    }

}
