using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HabraDrivenTests
{

    // Custom Data Row 
    public class HabrDataRow
    {
        public string Input { get; set; }
        public int Expected { get; set; }
        public Type ExpectedException { get; set; }
        public string Comment { get; set; }

    }
    
    [TestClass]
    public class HabrTestInherienceLoop : MsTestRows.Rows.TestRows_04<HabrDataRow>
    {
        // Production-ready method
        static int ConvertToNumber(string input)
        {
            int result = 0;
            while (input.Length > 0)
                result = (input[0] >= '0'
                || input[0] <= '9') ? (result
                * 10) + input[0] - '0' + (((input
                = input.Remove(0, 1)).Length
                > 0) ? 0 : 0) : 0;
            return result;
        }

        // Test Data
        static HabrDataRow[] testData = new HabrDataRow[]
        {
            #region Data
            new HabrDataRow()
            {
                 Input    = "0",
                 Expected = 0,
                 ExpectedException = null,
                 Comment = "Граничное значение",
            },
            new HabrDataRow()
            {
                 Input    = "1",
                 Expected = 1,
                 ExpectedException = null,
                 Comment = "Граничное значение",
            },
            new HabrDataRow()
            {
                 Input    = "-1",
                 Expected = -1,
                 ExpectedException = null,
                 Comment = "Граничное значение",
            },

            new HabrDataRow()
            {
                 Input    = "2147483647",
                 Expected = 2147483647,
                 ExpectedException = null,
                 Comment = "int.MaxValue",
            },
            #endregion
        };

        // Data Generator
        public override HabrDataRow GetNextDataRow(int rowIndex)
        {
            return testData[rowIndex];
        }

        // Test Implementation
        public override void TestMethod(HabrDataRow dataRow, int rowIndex)
        {
            int actualResult = ConvertToNumber(dataRow.Input);
            Assert.AreEqual(dataRow.Expected, actualResult);
        }
    }
}
