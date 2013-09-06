using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestRows
{
    public abstract class TestBase<DATAROW>
    {
        /// <summary>
        /// Derived class implements this method in order to return DATAROW according to rowIndex</summary>
        /// <param name="rowIndex"> ZERO-based row index. For instance, TestRow_01 sends rowIndex == 0</param>
        public abstract DATAROW GetNextDataRow(int rowIndex);

        /// <summary>
        /// Implement this method in derived class. This method should contain actual test implementation.</summary>
        /// <param name="rowIndex"> ZERO-based row index. For instance, TestRow_02 sends rowIndex == 1</param>
        /// <param name="dataRow">  Data from GetNextDataRow()</param>
        public abstract void TestMethod(DATAROW dataRow, int rowIndex);

        /// <summary>
        /// This method is called from TestRow_NNN. You don’t need to override it unless you want change some logic.</summary>
        /// <param name="rowIndex"> ZERO-based row index. For instance, TestRow_100 sends rowIndex == 99</param>
        public virtual void TestRowImplementation(int rowIndex)
        {
            DATAROW data = GetNextDataRow(rowIndex);
            TestMethod(data, rowIndex);
        }
    }
}
