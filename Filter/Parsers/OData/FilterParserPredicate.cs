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

using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Parsers.OData
{

    /// <summary>
    /// OData filter parser for predicate.
    /// </summary>
    public class FilterParserPredicate : IFilterParser
    {

        #region Public methods

        /// <summary>
        /// Determines if the parser is capable of handling a given filter type.
        /// </summary>
        /// <param name="filter">Filter to parse.</param>
        /// <returns>True if the parser can handle the given filter type.</returns>
        public bool IsHandledType(IFilter filter)
        {
            return filter is FilterPredicate;
        }

        /// <summary>
        /// Parses a filter into its filter string equivilent.
        /// </summary>
        /// <param name="filterParserService">Filter parser service.</param>
        /// <param name="filter">Filter to parse.</param>
        /// <returns>Filter string.</returns>
        public string ParseFilter<TFilterParserConfiguration>(IFilterService<TFilterParserConfiguration> filterParserService, IFilter filter) where TFilterParserConfiguration : IFilterServiceConfiguration, new()
        {
            if (!IsHandledType(filter))
                throw new ArgumentException($"Invalid filter type provided to parser.", nameof(filter));

            FilterPredicate predicate = (filter as FilterPredicate)!; // null hint...
            string result = string.Join(" ", ParseField(predicate), ParseOperator(predicate), ParseValue(filterParserService, predicate));

            return result;
        }

        #endregion

        #region Private static methods

        private static string ParseField(FilterPredicate predicate)
        {
            return predicate.Field;
        }

        private static string ParseOperator(FilterPredicate predicate)
        {
            string result = predicate.Operator switch
            {
                ComparisonOperator.Equals => "eq",
                ComparisonOperator.NotEquals => "ne",
                _ => throw new Exception($"Unhandled predicate operator {predicate.Operator}."),
            };

            return result;
        }

        private static string ParseValue<TFilterParserConfiguration>(IFilterService<TFilterParserConfiguration> filterParserService, FilterPredicate predicate) where TFilterParserConfiguration : IFilterServiceConfiguration, new()
        {
            return filterParserService.GetFilterValueString(predicate.Value);
        }

        #endregion

    }

}
