﻿using System.Linq;
using Harvester.Core.Filters;
using Xunit;

/* Copyright (c) 2012-2013 CBaxter
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
 * IN THE SOFTWARE. 
 */

namespace Harvester.Core.Tests.Filters.UsingComparisonFilter
{
    public class WhenCheckingGreaterThanOrEqual
    {
        [Fact]
        public void NotCompositeExpression()
        {
            var filter = new GreaterThanOrEqualFilter(new FakeExtendedProperties(), Enumerable.Empty<ICreateFilterExpressions>());

            Assert.False(filter.CompositeExpression);
        }

        [Fact]
        public void ReturnTrueIfGreaterThanOrEqual()
        {
            var e = new SystemEvent { ProcessId = 50 };
            var extendedProperties = new FakeExtendedProperties { { "property", "ProcessId" }, { "value", "50" } };
            var filter = new GreaterThanOrEqualFilter(extendedProperties, Enumerable.Empty<ICreateFilterExpressions>());

            Assert.True(Filter.Compile(filter).Invoke(e));
        }

        [Fact]
        public void ReturnFalseIfNotGreaterThanOrEqual()
        {
            var e = new SystemEvent { ProcessId = 49 };
            var extendedProperties = new FakeExtendedProperties { { "property", "ProcessId" }, { "value", "50" } };
            var filter = new GreaterThanOrEqualFilter(extendedProperties, Enumerable.Empty<ICreateFilterExpressions>());

            Assert.False(Filter.Compile(filter).Invoke(e));
        }
    }
}