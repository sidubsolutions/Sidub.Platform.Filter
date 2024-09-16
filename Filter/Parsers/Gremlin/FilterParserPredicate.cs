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

namespace Sidub.Platform.Filter.Parsers.Gremlin
{

    /// <summary>
    /// Gremlin filter parser for predicate.
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
        /// Parses a filter into its filter string equivalent.
        /// </summary>
        /// <typeparam name="TFilterParserConfiguration">The type of the filter parser configuration.</typeparam>
        /// <param name="filterParserService">Filter parser service.</param>
        /// <param name="filter">Filter to parse.</param>
        /// <returns>Filter string.</returns>
        public string ParseFilter<TFilterParserConfiguration>(IFilterService<TFilterParserConfiguration> filterParserService, IFilter filter) where TFilterParserConfiguration : IFilterServiceConfiguration, new()
        {
            if (!IsHandledType(filter))
                throw new ArgumentException($"Invalid filter type provided to parser.", nameof(filter));

            FilterPredicate predicate = (filter as FilterPredicate)!;
            string result = $"values('{ParseField(predicate)}').is({ParseOperatorAndValue(filterParserService, predicate)})";

            return result;
        }

        #endregion

        #region Private static methods

        /// <summary>
        /// Parses the field of the filter predicate.
        /// </summary>
        /// <param name="predicate">The filter predicate.</param>
        /// <returns>The parsed field.</returns>
        private static string ParseField(FilterPredicate predicate)
        {
            return predicate.Field;
        }

        /// <summary>
        /// Parses the operator and value of the filter predicate.
        /// </summary>
        /// <typeparam name="TFilterParserConfiguration">The type of the filter parser configuration.</typeparam>
        /// <param name="filterParserService">Filter parser service.</param>
        /// <param name="predicate">The filter predicate.</param>
        /// <returns>The parsed operator and value.</returns>
        private static string ParseOperatorAndValue<TFilterParserConfiguration>(IFilterService<TFilterParserConfiguration> filterParserService, FilterPredicate predicate) where TFilterParserConfiguration : IFilterServiceConfiguration, new()
        {
            string result = string.Empty;
            string? operatorWrapStart = null;
            string? operatorWrapEnd = null;

            switch (predicate.Operator)
            {
                case ComparisonOperator.Equals:
                    break;
                case ComparisonOperator.NotEquals:
                    operatorWrapStart = "not(";
                    operatorWrapEnd = ")";
                    break;
                default:
                    throw new Exception($"Unhandled predicate operator {predicate.Operator}.");
            }

            if (!string.IsNullOrEmpty(operatorWrapStart))
            {
                result += operatorWrapStart;
            }

            result += filterParserService.GetFilterValueString(predicate.Value);

            if (!string.IsNullOrEmpty(operatorWrapEnd))
            {
                result += operatorWrapEnd;
            }

            return result;
        }

        #endregion

    }

}
