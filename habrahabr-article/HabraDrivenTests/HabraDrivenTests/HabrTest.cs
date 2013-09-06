using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HabraDrivenTests
{
    [TestClass]
    public class HabrTest
    {
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


        const string dataDriver = "System.Data.OleDb";
        const string connectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\matrix.xlsx;Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";

        [TestMethod]
        [DataSource(dataDriver, connectionStr, "Shit1$", DataAccessMethod.Sequential)]
        public void TestMe()
        {
            string rowInput     = TestContext.DataRow["Input"].ToString();
            string rowExpected  = TestContext.DataRow["Expected Result"].ToString();
            string rowException = TestContext.DataRow["Exception"].ToString();
            string rowComment   = TestContext.DataRow["Comment"].ToString();

            int actualResult = ConvertToNumber(rowInput);
            Assert.AreEqual(rowExpected, actualResult.ToString());
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    }
}
