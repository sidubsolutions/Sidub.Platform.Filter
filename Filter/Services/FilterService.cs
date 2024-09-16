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

using Sidub.Platform.Filter.Parsers;

#endregion

namespace Sidub.Platform.Filter.Services
{

    /// <summary>
    /// Filter parser service providing functionality for parsing filter objects and filter values.
    /// </summary>
    public class FilterService<TFilterParserConfiguration> : IFilterService<TFilterParserConfiguration> where TFilterParserConfiguration : IFilterServiceConfiguration, new()
    {

        #region Public properties

        /// <summary>
        /// Gets the filter parser configuration.
        /// </summary>
        public TFilterParserConfiguration FilterParserConfiguration { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterService{TFilterParserConfiguration}"/> class.
        /// </summary>
        /// <param name="globalValueParsers">The global value parsers to use during filter string parsing.</param>
        public FilterService(IEnumerable<IFilterValueParser> globalValueParsers)
        {
            FilterParserConfiguration = new TFilterParserConfiguration();
            FilterParserConfiguration.ValueParsers.AddRange(globalValueParsers);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the filter string equivalent of a given filter.
        /// </summary>
        /// <param name="filter">The filter to parse.</param>
        /// <returns>The filter string equivalent of the filter.</returns>
        public string GetFilterString(IFilter? filter)
        {
            string result = string.Empty;

            if (filter is null)
                return result;

            bool isHandled = false;

            foreach (var i in FilterParserConfiguration.FilterParsers)
            {
                if (i.IsHandledType(filter))
                {
                    isHandled = true;
                    // TODO - review this interface cast, etc... - its quite odd...
                    result = i.ParseFilter(this, filter);
                }
            }

            if (!isHandled)
                throw new Exception($"Filter parser not found for IFilter type '{ReflectionHelper.GetFilterTypeName(filter)}'.");

            return result;
        }

        /// <summary>
        /// Parses a filter value to its filter string equivalent.
        /// </summary>
        /// <param name="value">The filter value to parse.</param>
        /// <returns>The filter string equivalent of the filter value.</returns>
        public string GetFilterValueString(object? value)
        {
            string result = string.Empty;
            bool isHandled = false;

            if (value is null)
                return result;

            foreach (var i in FilterParserConfiguration.ValueParsers)
            {
                if (i.IsHandledType(value))
                {
                    isHandled = true;
                    result = i.ParseFilterValue(value);
                }
            }

            if (!isHandled)
                throw new Exception($"Filter value parser not found for object type '{ReflectionHelper.GetFilterValueTypeName(value)}'. If this is not the intended data source type, ensure correct definition of type on entity field attribute.");

            return result;
        }

        #endregion

    }

}
