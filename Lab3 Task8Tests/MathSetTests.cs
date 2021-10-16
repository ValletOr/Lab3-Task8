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
        public void Constructor()
        {
            MathSet b = new MathSet("1 2 3 4 5 6 7 8 9 10 ");
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 10 ", b.Verbose());
        }

        [TestMethod()]
        public void ObjPlusObj()
        {
            MathSet a = new MathSet("1 2 3 4 5 6 7 8 9 10");
            MathSet b = new MathSet("8 9 10 11 12 13 14 15");
            MathSet c = a + b;
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 ", c.Verbose());
        }

        [TestMethod()]
        public void ObjObj()
        {
            MathSet a = new MathSet("1 2 3 4 5 6 7 8 9 10");
            MathSet b = new MathSet("8 9 10 11 12 13 14 15");
            MathSet c = a * b;
            Assert.AreEqual("8 9 10 ", c.Verbose());
        }

        [TestMethod()]
        public void ObjMinusObj()
        {
            MathSet a = new MathSet("1 2 3 4 5 6 7 8 9 10");
            MathSet b = new MathSet("8 9 10 11 12 13 14 15");
            MathSet c = a - b;
            Assert.AreEqual("1 2 3 4 5 6 7 ", c.Verbose());
        }

        [TestMethod()]
        public void ObjPlusNum()
        {
            MathSet a = new MathSet("1 2 3 4 5 6 7 8 9 10");
            int b = 11;
            MathSet c = a + b;
            Assert.AreEqual("1 2 3 4 5 6 7 8 9 10 11 ", c.Verbose());
        }

        [TestMethod()]
        public void ObjMinusNum()
        {
            MathSet a = new MathSet("1 2 3 4 5 6 7 8 9 10");
            int b = 7;
            MathSet c = a - b;
            Assert.AreEqual("1 2 3 4 5 6 8 9 10 ", c.Verbose());
        }
    }
}