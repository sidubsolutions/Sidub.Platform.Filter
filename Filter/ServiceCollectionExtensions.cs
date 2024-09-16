/*
 * Sidub Platform - Filter
 * Copyright (C) 2024 Sidub Inc.
 * All rights reserved.
 *
 * This file is part of Sidub Platform - Filter (the "Product").
 *
 * The Product is dual-licensed under:
 * 1. The GNU Affero General Public License version 3 (AGPLv3)
 * 2. Sidub Inc.'s Proprietary Software License Agreement (PSLA)
 *
 * You may choose to use, redistribute, and/or modify the Product under
 * the terms of either license.
 *
 * The Product is provided "AS IS" and "AS AVAILABLE," without any
 * warranties or conditions of any kind, either express or implied, including
 * but not limited to implied warranties or conditions of merchantability and
 * fitness for a particular purpose. See the applicable license for more
 * details.
 *
 * See the LICENSE.txt file for detailed license terms and conditions or
 * visit https://sidub.ca/licensing for a copy of the license texts.
 */

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
