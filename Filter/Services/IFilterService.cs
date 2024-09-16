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
