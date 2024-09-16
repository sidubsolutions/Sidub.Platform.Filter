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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sidub.Platform.Filter.Parsers.MySql;
using Sidub.Platform.Filter.Services;

#endregion

namespace Sidub.Platform.Filter.Test
{

    /// <summary>
    /// Tests the filter framework and the JSON filter string implementation.  by examining filter string parser results from the 
    /// </summary>
    [TestClass]
    public class MySqlFilterParserTest
    {

        private readonly IFilterService<MySqlFilterConfiguration> _filterParserService;

        public MySqlFilterParserTest()
        {
            // initialize dependency injection environment...
            var serviceProvider = new ServiceCollection()
                .AddSidubFilter(FilterParserType.MySql)
                .BuildServiceProvider();

            _filterParserService = serviceProvider.GetService<IFilterService<MySqlFilterConfiguration>>() ?? throw new Exception("Filter parser service not initialized.");
        }

        [TestMethod]
        public void ODataFilterParserTest_FilterString01()
        {
            var builder = new FilterBuilder();
            builder.Add("FieldA", ComparisonOperator.Equals, "FieldATestValue");

            var filter = builder.Build();
            var filterString = _filterParserService.GetFilterString(filter);

            Assert.AreEqual("FieldA = 'FieldATestValue'", filterString);
        }

        [TestMethod]
        public void ODataFilterParserTest_FilterString02()
        {
            var builder = new FilterBuilder();
            builder.Add("FieldA", ComparisonOperator.Equals, "FieldATestValue")
                .Add(LogicalOperator.And)
                .Add("FieldB", ComparisonOperator.NotEquals, "FieldBTestValue");

            var filter = builder.Build();
            var filterString = _filterParserService.GetFilterString(filter);

            Assert.AreEqual("(FieldA = 'FieldATestValue' and FieldB != 'FieldBTestValue')", filterString);
        }

        [TestMethod]
        public void ODataFilterParserTest_FilterString03()
        {
            var builder = new FilterBuilder();
            builder.Add("FieldA", ComparisonOperator.Equals, "FieldATestValue")
                .Add(LogicalOperator.And)
                .Add(inner1 => inner1.Add("FieldB", ComparisonOperator.Equals, "FieldBTestValue01")
                                    .Add(LogicalOperator.Or)
                                    .Add("FieldB", ComparisonOperator.Equals, "FieldBTestValue02"));

            var filter = builder.Build();
            var filterString = _filterParserService.GetFilterString(filter);

            Assert.AreEqual("(FieldA = 'FieldATestValue' and (FieldB = 'FieldBTestValue01' or FieldB = 'FieldBTestValue02'))", filterString);
        }

        [TestMethod]
        public void ODataFilterParserTest_UnhandledValueType01()
        {
            var value = new KeyValuePair<string, int>("key", 1);

            var builder = new FilterBuilder();
            builder.Add("FieldA", ComparisonOperator.Equals, value);

            var filter = builder.Build();

            Assert.ThrowsException<Exception>(() => _ = _filterParserService.GetFilterString(filter));
        }

    }

}
