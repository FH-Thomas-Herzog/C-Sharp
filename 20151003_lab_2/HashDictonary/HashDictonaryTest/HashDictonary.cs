using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashDictonary;
using System.Collections.Generic;

namespace HashDictonaryTest
{
    [TestClass]
    public class HashDictonary
    {
        [TestMethod]
        public void CountZero()
        {
            // Given | When 
            int expectedCount = 0;
            var dictonary = new HashDictonary<int, string>();

            // Then
            Assert.AreEqual(expectedCount, dictonary.Count);
        }

        [TestMethod]
        public void CountInserted()
        {
            // Given 
            int expectedCount = 3;
            var dictonary = new HashDictonary<int, string>();

            // When 
            dictonary.Add(1, "Hugo");
            dictonary.Add(2, "Franz");
            dictonary.Add(3, "Rudi");

            // Then
            Assert.AreEqual(expectedCount, dictonary.Count);
        }

        [TestMethod]
        public void DuplicateKeyInserted()
        {
            // Given 
            var dictonary = new HashDictonary<int, string>();

            // When 
            dictonary.Add(1, "Hugo");
            dictonary[1] = "Franz";

            try
            {
                dictonary.Add(1, "Rudi");

                Assert.Fail("ArgumentException expected");
            }
            catch (ArgumentException)
            {
                // Then
            }
        }

        // Then
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void KeyNotFound()
        {
            // Given 
            var dictonary = new HashDictonary<int, string>() {
                { 1, "Hugo"},
                { 2, "Franz"},
                { 3, "Rudi"}
            };

            // When 
            var name = dictonary[4];
        }
    }
}
