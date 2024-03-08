#region Imports

using Sidub.Platform.Filter.Parsers;

#endregion

namespace Sidub.Platform.Filter.Services
{

    /// <summary>
    /// Represents the configuration for filter parsers.
    /// </summary>
    public interface IFilterServiceConfiguration
    {

        #region Interface methods

        /// <summary>
        /// Gets the list of filter parsers.
        /// </summary>
        List<IFilterParser> FilterParsers { get; }

        /// <summary>
        /// Gets the list of value parsers.
        /// </summary>
        List<IFilterValueParser> ValueParsers { get; }

        #endregion

    }

}
