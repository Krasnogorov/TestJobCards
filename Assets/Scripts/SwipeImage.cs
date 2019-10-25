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
    public class SwipeImage : MonoBehaviour, IDragHandler, IEndDragHandler, ISwipeable
    {
        /// image 
        [SerializeField]
        private Image _image = null;
        /// textl label
        [SerializeField]
        private Text _text = null;
        /// animation component
        [SerializeField]
        private Animation _animation = null;
        /// callback for swipe action
        private Action<bool> _resultCallback;
        /// start position
        private Vector3 _position = Vector3.zero;
        /// max distance for success swipe effect
        private const float MAX_DISTANCE = 300.0f;
        /// speed of hiding element
        private const float SPEED = 10000.0f;
        /// offset for hiding
        private const float HIDE_DISTANCE = 5000.0f;

        private bool _isExit = false;
        private Vector3 _exitPosition;
       
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
            
            if (distance > MAX_DISTANCE)
            {
                _isExit = true;
                _exitPosition = eventData.position;
                _exitPosition.x += (transform.position.x > _position.x) ? HIDE_DISTANCE : -HIDE_DISTANCE;
                
            }
            else
            {
                transform.position = _position;
                _animation.Play();
                _resultCallback?.Invoke(false);
            }
        }

        private void FixedUpdate()
        {
            if (_isExit)
            {
                float step = SPEED * Time.deltaTime; 
                transform.position = Vector3.MoveTowards(transform.position, _exitPosition, step);

                if (Vector3.Distance(transform.position, _exitPosition) < Mathf.Epsilon)
                {
                    _isExit = false;
                    transform.position = _position;
                    _animation.Play();
                    _resultCallback?.Invoke(true);
                }
            }
        }
    }
}