using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestRows.From_1_to_10
{
    [TestClass]
    public abstract class TestRows_1<DATAROW> : TestBase<DATAROW>
    {
        [TestMethod]
        public void TestRow_001()
        {
            TestRowImplementation(001);
        }
    }
}