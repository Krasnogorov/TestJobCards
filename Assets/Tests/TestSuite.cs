using System.Collections;
using System.Collections.Generic;
using Controllers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class SaveManagerTest
    {
        private const string INT_VALUE_KEY = "test_int_key";

        [UnityTest]
        public IEnumerator SaveTest()
        {
            int value = 10;
            SaveManager.Instance.SetIntForKey(INT_VALUE_KEY, value);
            yield return new WaitForSeconds(0.1f);
            int ret = SaveManager.Instance.GetIntForKey(INT_VALUE_KEY);
            Assert.AreEqual(value, ret);

            value = -100500;
            SaveManager.Instance.SetIntForKey(INT_VALUE_KEY, value);
            yield return new WaitForSeconds(0.1f);
            ret = SaveManager.Instance.GetIntForKey(INT_VALUE_KEY);
            Assert.AreEqual(value, ret);

            value = int.MaxValue;
            SaveManager.Instance.SetIntForKey(INT_VALUE_KEY, value);
            yield return new WaitForSeconds(0.1f);
            ret = SaveManager.Instance.GetIntForKey(INT_VALUE_KEY);
            Assert.AreEqual(value, ret);

            value = int.MaxValue;
            value++;
            SaveManager.Instance.SetIntForKey(INT_VALUE_KEY, value);
            yield return new WaitForSeconds(0.1f);
            ret = SaveManager.Instance.GetIntForKey(INT_VALUE_KEY);
            Assert.AreEqual(value, ret);
        }       
    }
}
