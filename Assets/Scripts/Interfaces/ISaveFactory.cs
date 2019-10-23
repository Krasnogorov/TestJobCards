using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    /// <summary>
    /// Interface for factory for saving user's information to storage like PlayerPrefs, iNotes, Googlegrive, etc.
    /// </summary>
    public interface ISaveFactory
    {
        /// <summary>
        /// Receive int value from storage by string key
        /// </summary>
        /// <param name="key">key for saving</param>
        /// <param name="defaultValue">default value which will be returned if value will not found</param>
        /// <returns></returns>
        int GetIntForKey(string key, int defaultValue = 0);
        /// <summary>
        /// Save int value to storage
        /// </summary>
        /// <param name="key">key for saving</param>
        /// <param name="value">value for saving</param>
        void SetIntForKey(string key, int value);
    }
}