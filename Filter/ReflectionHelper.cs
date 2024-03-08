#region Imports


#endregion

namespace Sidub.Platform.Filter
{

    /// <summary>
    /// Static helper class providing reflection utilities.
    /// </summary>
    public static class ReflectionHelper
    {

        #region Public static methods

        /// <summary>
        /// Retrieves textual display name for an IFilter type.
        /// </summary>
        /// <param name="filter">The IFilter object.</param>
        /// <returns>The display name of the filter type.</returns>
        public static string GetFilterTypeName(IFilter filter)
        {
            return filter.GetType().Name;
        }

        /// <summary>
        /// Retrieves textual display name for a filter value type.
        /// </summary>
        /// <param name="value">The filter value object.</param>
        /// <returns>The display name of the filter value type.</returns>
        public static string GetFilterValueTypeName(object? value)
        {
            return value?.GetType()?.Name ?? "<null>";
        }

        #endregion

    }
}
