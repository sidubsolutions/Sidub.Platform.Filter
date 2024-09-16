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

using Sidub.Platform.Filter.Builders;

#endregion

namespace Sidub.Platform.Filter
{

    /// <summary>
    /// Basic filter builder providing fluent filter creation.
    /// </summary>
    public class FilterBuilder : IFilterBuilder, IFilterBuilderStatement, IFilterBuilderJoin
    {

        #region Member variables

        private List<IFilter> Filters { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterBuilder"/> class.
        /// </summary>
        public FilterBuilder()
        {
            Filters = new List<IFilter>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add a pipeline builder to the builder.
        /// </summary>
        /// <param name="pipelineBuilder">Builder for assembling a pipeline.</param>
        /// <returns>An <see cref="IFilterBuilderJoin"/> for the next step in the builder.</returns>
        public IFilterBuilderJoin Add(Action<IFilterBuilderStatement> pipelineBuilder)
        {
            // create a new builder to capture inner...
            var builder = new FilterBuilder();

            // provide the builder through the action...
            pipelineBuilder(builder);

            // create a pipeline filter from the builder...
            var pipeline = new FilterPipeline();
            foreach (var filter in builder.Filters)
            {
                pipeline.AddFilter(filter);
            }

            // add the pipeline to this builder...
            Filters.Add(pipeline);

            return this;
        }

        /// <summary>
        /// Adds a predicate to the builder.
        /// </summary>
        /// <param name="filterField">Filter field.</param>
        /// <param name="operator">Filter operator.</param>
        /// <param name="value">Filter value.</param>
        /// <returns>An <see cref="IFilterBuilderJoin"/> for the next step in the builder.</returns>
        public IFilterBuilderJoin Add(string filterField, ComparisonOperator @operator, object value)
        {
            // add the filter predicate to this builder...
            var filterPredicate = new FilterPredicate(filterField, @operator, value);

            Filters.Add(filterPredicate);

            return this;
        }

        /// <summary>
        /// Add a logical operator to the builder.
        /// </summary>
        /// <param name="operator">Logical operator type.</param>
        /// <returns>An <see cref="IFilterBuilderStatement"/> for the next step in the builder.</returns>
        public IFilterBuilderStatement Add(LogicalOperator @operator)
        {
            // add the operator to this builder...
            var filterOperator = new FilterLogicalOperator(@operator);

            Filters.Add(filterOperator);

            return this;
        }

        /// <summary>
        /// Validates the state of the builder to ensure a proper <see cref="IFilter"/> expression
        /// may be built.
        /// </summary>
        /// <returns>True if the builder is valid.</returns>
        public bool IsValid()
        {
            // TODO - validation such as checking that the pipeline does not end with a logical operator...

            return true;
        }

        /// <summary>
        /// Executes the builder and returns the resulting <see cref="IFilter"/> representation.
        /// </summary>
        /// <returns>Filter.</returns>
        public IFilter? Build()
        {
            // ensure valid...
            if (!IsValid())
                throw new NotImplementedException("TODO");

            // if we only have a single filter, we can return it as is... otherwise we need to add the filters
            //  into a pipeline and return that as the filter object...
            if (Filters.Count == 1)
            {
                return Filters[0];
            }
            else if (Filters.Count > 1)
            {
                var pipeline = new FilterPipeline();

                Filters.ForEach(x => pipeline.AddFilter(x));

                return pipeline;
            }

            // no filters exist...
            return null;
        }

        #endregion

    }
}
