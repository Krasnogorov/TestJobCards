using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class SaveManager 
    {
        private static SaveManager _instance = null;

        private ISaveFactory _saveFactory = null;

        public static SaveManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SaveManager();
                    _instance.Init();
                }
                return _instance;
            }
        }

        private void Init()
        {
            _saveFactory = new UnitySaveFactory();
        }

        public int GetIntForKey(string key, int defaultValue = 0)
        {
            return _saveFactory.GetIntForKey(key, defaultValue);
        }

        public void SetIntForKey(string key, int value)
        {
            _saveFactory.SetIntForKey(key, value);
        }
    }
}