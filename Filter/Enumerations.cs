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

namespace Sidub.Platform.Filter
{

    #region Enumerations

    /// <summary>
    /// Filter parser implementations.
    /// </summary>
    [Flags]
    public enum FilterParserType
    {
        /// <summary>
        /// OData filter parser.
        /// </summary>
        OData = 1 << 1,

        /// <summary>
        /// Gremlin filter parser.
        /// </summary>
        Gremlin = 1 << 2,

        /// <summary>
        /// MySql filter parser.
        /// </summary>
        MySql = 1 << 3
    }

    /// <summary>
    /// Filter logical operators.
    /// </summary>
    public enum LogicalOperator
    {
        /// <summary>
        /// Logical AND operator.
        /// </summary>
        And,

        /// <summary>
        /// Logical OR operator.
        /// </summary>
        Or
    }

    /// <summary>
    /// Filter predicate comparison operators.
    /// </summary>
    public enum ComparisonOperator
    {
        /// <summary>
        /// Equality comparison operator.
        /// </summary>
        Equals,

        /// <summary>
        /// Inequality comparison operator.
        /// </summary>
        NotEquals
    }

    #endregion

}
