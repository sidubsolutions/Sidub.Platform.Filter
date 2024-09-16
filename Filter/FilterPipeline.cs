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

namespace Sidub.Platform.Filter
{

    /// <summary>
    /// Defines a filter pipeline component; encapsulates multiple filter operations and enforces
    /// order of operations.
    /// </summary>
    public class FilterPipeline : IFilter
    {
        #region Public properties

        /// <summary>
        /// Gets the filters contained within the pipeline.
        /// </summary>
        public List<IFilter> Filters { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterPipeline"/> class.
        /// </summary>
        internal FilterPipeline()
        {
            Filters = new List<IFilter>();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds a filter to the pipeline.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        /// <exception cref="ArgumentException">Thrown when the filter is null.</exception>
        public void AddFilter(IFilter filter)
        {
            if (filter == null)
                throw new ArgumentException("Cannot add a null filter into the pipeline.", nameof(filter));

            Filters.Add(filter);
        }

        #endregion
    }

}
