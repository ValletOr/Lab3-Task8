using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3_Task8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Task8.Tests
{
    [TestClass()]
    public class MathSetTests
    {
        [TestMethod()]
        public void First()
        {
            string a = "1 2 3 4 5 6 7 8 9 10";
            MathSet b = new MathSet(a);
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 10 ", b.Verbose());
        }
    }
}