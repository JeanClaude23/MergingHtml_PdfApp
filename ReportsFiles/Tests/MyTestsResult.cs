using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReportsFiles.Tests
{
    [TestFixture]
    class MyTestsResult
    {
        [Test]
        public void TestMethod1()
        {
            // Test code here

            string result = "Test passed";
            string filePath = @"D:\Reports\test_report.txt";
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(result);
            }
        }

        [Test]
        public void TestMethod2()
        {
            // Test code here

            string result = "Test failed";
            string filePath = @"C:\TestResults\test_report.txt";
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(result);
            }
        }
    }
}
