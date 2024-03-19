#region Imports

using Microsoft.Extensions.DependencyInjection;
using Sidub.Platform.Filter.Parsers.Gremlin;
using Sidub.Platform.Filter.Parsers.MySql;
using Sidub.Platform.Filter.Parsers.OData;
using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter
{

    /// <summary>
    /// Static helper class providing IServiceCollection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        #region Extension methods

        /// <summary>
        /// Registers the Sidub filter system within the container. Initializes base configuration.
        /// </summary>
        /// <param name="services">IServiceCollection extension.</param>
        /// <param name="parser">Filter parser configuration type.</param>
        /// <returns>IServiceCollection result.</returns>
        public static IServiceCollection AddSidubFilter(
            this IServiceCollection services, FilterParserType? parser = null)
        {
            if (parser?.HasFlag(FilterParserType.OData) ?? false)
                services.AddTransient<IFilterService<ODataFilterConfiguration>, ODataFilterService>();

            if (parser?.HasFlag(FilterParserType.Gremlin) ?? false)
                services.AddTransient<IFilterService<GremlinFilterConfiguration>, GremlinFilterService>();

            if (parser?.HasFlag(FilterParserType.MySql) ?? false)
                services.AddTransient<IFilterService<MySqlFilterConfiguration>, MySqlFilterService>();

            return services;
        }

        #endregion

    }
}
