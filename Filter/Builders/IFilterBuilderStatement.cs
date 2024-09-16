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

namespace Sidub.Platform.Filter.Builders
{

    /// <summary>
    /// Filter component(s) builder interface for statements. Used for building the statement portion
    /// (i.e., a predicate or pipeline) of a filter clause.
    /// </summary>
    public interface IFilterBuilderStatement : IFilterBuilder
    {

        #region Interface methods

        /// <summary>
        /// Add a pipeline builder to the builder.
        /// </summary>
        /// <param name="pipelineBuilder">Builder for assembling a pipeline.</param>
        /// <returns>An IFilterBuilderJoin for the next step in the builder.</returns>
        IFilterBuilderJoin Add(Action<IFilterBuilderStatement> pipelineBuilder);

        /// <summary>
        /// Adds a predicate to the builder.
        /// </summary>
        /// <param name="filterField">Filter field.</param>
        /// <param name="operator">Filter operator.</param>
        /// <param name="value">Filter value.</param>
        /// <returns>An IFilterBuilderJoin for the next step in the builder.</returns>
        IFilterBuilderJoin Add(string filterField, ComparisonOperator @operator, object value);

        #endregion

    }
}
