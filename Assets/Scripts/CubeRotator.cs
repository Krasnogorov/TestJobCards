using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Class for rotate cube in main menu
    /// </summary>
    public class CubeRotator : MonoBehaviour
    {
        /// speed of rotation
        [SerializeField]
        private float _rotationSpeed = 100.0f;
        /// direction of rotation
        [SerializeField]
        private Vector3 _rotationDirection = Vector3.one;

        private void FixedUpdate()
        {
            gameObject.transform.Rotate(_rotationDirection, Time.deltaTime * _rotationSpeed);
        }
    }
}