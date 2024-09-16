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

namespace Sidub.Platform.Filter.Parsers.Gremlin
{

    /// <summary>
    /// Gremlin filter value parser for Guid values.
    /// </summary>
    public class FilterValueParserGuid : IFilterValueParser
    {

        #region Public methods

        /// <summary>
        /// Determines if the parser is capable of handling a given filter value type.
        /// </summary>
        /// <param name="filterValue">The filter value to parse.</param>
        /// <returns>True if the parser can handle the given filter value type, otherwise false.</returns>
        public bool IsHandledType(object filterValue)
        {
            return filterValue is Guid;
        }

        /// <summary>
        /// Parses a filter value to its string equivalent.
        /// </summary>
        /// <param name="value">The filter value to parse.</param>
        /// <returns>The string equivalent of the filter value.</returns>
        public string ParseFilterValue(object value)
        {
            Guid guidValue = (Guid)value;

            return $"'{guidValue:D}'";
        }

        #endregion

    }

}
