﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Com.DDS.FuelTracker.Tests.Domain.Model.Station
{
    /// <summary>
    /// Summary description for StationTest
    /// </summary>
    [TestClass]
    public class StationTest
    {
        public StationTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Station_IdWithZeroThrowsException()
        {
            var result = new FuelTracker.Domain.Model.Station.StationId(0);
        }

        [TestMethod]
        public void Station_IdCreatedCorrectly()
        {
            var result = new FuelTracker.Domain.Model.Station.StationId(10);
            Assert.AreEqual((Int32)10, result.Value);
        }


        [TestMethod]
        public void Station_AggregateCreatedCorrectly()
        {
            var testID = new FuelTracker.Domain.Model.Station.StationId(10);
            var testName = "Test Name";
            var result = new FuelTracker.Domain.Model.Station.StationAggregate(testID,
                                                                               testName);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.StationName == testName);
            Assert.IsTrue(result.ConcurrencyVersion == 0);
            Assert.AreEqual(testID, result.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Station_AggregateCreateInvalid_EmptyName()
        {
            var testID = new FuelTracker.Domain.Model.Station.StationId(10);
            var testName = string.Empty;
            var result = new FuelTracker.Domain.Model.Station.StationAggregate(testID,
                                                                               testName);
            Assert.IsNull(result);
        }

    }
}
