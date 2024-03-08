#region Imports

#endregion

namespace Sidub.Platform.Filter.Services
{

    /// <summary>
    /// Filter parser service interface.
    /// </summary>
    public interface IFilterService<TConfiguration> where TConfiguration : IFilterServiceConfiguration
    {

        #region Interface properties

        /// <summary>
        /// Gets the filter parser configuration.
        /// </summary>
        TConfiguration FilterParserConfiguration { get; }

        #endregion

        #region Interface methods

        /// <summary>
        /// Gets the filter string equivalent of a given filter.
        /// </summary>
        /// <param name="filter">The filter to parse.</param>
        /// <returns>The filter string equivalent of the filter.</returns>
        string GetFilterString(IFilter? filter);

        /// <summary>
        /// Gets the filter string equivalent of a given filter value.
        /// </summary>
        /// <param name="value">The filter value to parse.</param>
        /// <returns>The filter string equivalent of the filter value.</returns>
        string GetFilterValueString(object? value);

        #endregion

    }

}
