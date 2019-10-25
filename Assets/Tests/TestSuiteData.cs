using System.Collections;
using System.Collections.Generic;
using Data;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class TestSuiteData
    {
        private ImageCollection _collection;

        [SetUp]
        public void Setup()
        {
            _collection = Resources.Load<ImageCollection>("testResourceCollection");
        }

        [UnityTest]
        public IEnumerator TestDataValidation()
        {
            Assert.AreEqual(_collection.GetItem(0).Text, "first");
            Assert.AreEqual(_collection.Length, 7);

            Assert.DoesNotThrow(() => { _collection.GetItem(_collection.Length + 1); });
            Assert.DoesNotThrow(() => { _collection.GetItem(-1); });

            Assert.AreEqual(_collection.GetItem(int.MaxValue), null);
            yield return null;
        }
    }
}
