using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ImageCollection", menuName = "Create Image Database")]
    public class ImageCollection : ScriptableObject
    {
        /// list of items
        [SerializeField]
        private List<ImageData> _items = new List<ImageData>();

        /// <summary>
        /// Receive length of collection
        /// </summary>
        public int Length
        {
            get
            {
                return _items.Count;
            }
        }
        /// <summary>
        /// Receive item by name
        /// </summary>
        /// <param name="name">name of item</param>
        /// <returns>serialized item or null</returns>
        public ImageData GetItem(int index)
        {
            return (index >= 0 && index < _items.Count) ? _items[index] : null;
        }
    }
}