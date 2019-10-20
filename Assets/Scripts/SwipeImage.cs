using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class for control image with swipe effect
    /// </summary>
    public class SwipeImage : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        /// image 
        [SerializeField]
        private Image _image = null;
        /// textl label
        [SerializeField]
        private Text _text = null;
        /// callback for swipe action
        private Action<bool> _resultCallback;
        /// start position
        private Vector3 _position = Vector3.zero;
        /// max distance for success swipe effect
        private const float MAX_DISTANCE = 100.0f;

        private void Start()
        {
            _position = transform.position;
        }
        /// <summary>
        /// Display selected image
        /// </summary>
        /// <param name="imageData">data of image</param>
        /// <param name="callback">callback for event</param>
        public void DisplayImage(ImageData imageData, Action<bool> callback)
        {
            _resultCallback = callback;
            _image.sprite = imageData.Image;
            _text.text = imageData.Text;
        }      

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = new Vector3(eventData.position.x, transform.position.y);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float distance = Vector3.Distance(_position, eventData.position);
            
            transform.position = _position;
            _resultCallback?.Invoke(distance > MAX_DISTANCE);
        }
    }
}