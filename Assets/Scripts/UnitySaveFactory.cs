using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Implementation of ISaveFactory with PlayerPrefs
    /// </summary>
    public class UnitySaveFactory : ISaveFactory
    {
        public int GetIntForKey(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public void SetIntForKey(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
    }
}