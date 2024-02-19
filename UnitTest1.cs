using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Azimut;
using System.Collections.Generic;

namespace UnitTestProjectAzimut
{
    [TestClass]
    public class UnitTestPoint
    {
        [DataRow(-1000.0, -1000.0)]
        [DataRow(-1000.0, 1000.0)]
        [DataRow(1000.0, -1000.0)]
        [DataRow(1000.0, 1000.0)]
        [DataRow(-90.01, -180.1)]
        [DataRow(-90.01, 180.1)]
        [DataRow(90.01, -180.1)]
        [DataRow(90.01, 180.1)]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodCtor_ThrowsArgumentOutOfRangeException(double a, double b)
        {
            Point p;
            p = new Point(a, b);
        }
        [DataRow(-89.01, -179.01)]
        [DataRow(-89.01, 179.01)]
        [DataRow(89.01, -179.01)]
        [DataRow(89.01, 179.01)]
        [DataTestMethod]
        public void TestMethodCtor_CreatePoint(double a, double b)
        {
            Point p;
            p = new Point(a, b);
            Assert.IsNotNull(p);
        }
    }

    [TestClass]
    public class UnitTestDistanceAzimuth
    {
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void TestMethodCtor_CreateObject(Point a, Point b)
        {
           
            DistanceAzimuth da;
            da = new DistanceAzimuth(a, b);
            Assert.AreEqual(da.A.Latitude, a.Latitude);
            Assert.AreEqual(da.B.Latitude, b.Latitude);
            Assert.AreEqual(da.A.Longitude, a.Longitude);
            Assert.AreEqual(da.B.Longitude, b.Longitude);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new Point(70.0, 80.0), new Point(89.0, 179.0) };
            yield return new object[] { new Point(89.0, 179.0), new Point(-89.0, -179.0) };
        }
    }
    
}
