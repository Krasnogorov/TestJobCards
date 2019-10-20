using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    /// <summary>
    /// Information about image
    /// </summary>
    [Serializable]
    public class ImageData 
    {
        /// text of image
        [SerializeField]
        private string _text = "";
        /// sprite of image
        [SerializeField]
        private Sprite _image = null;

        public string Text
        {
            get
            {
                return _text;
            }
        }

        public Sprite Image
        {
            get
            {
                return _image;
            }
        }
    }
}