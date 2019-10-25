using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public enum SwipeDirection
    {
        None,
        Left,
        Right
    }
    public interface ISwipeable
    {
        void DisplayImage(ImageData imageData, Action<bool, SwipeDirection> callback);
    }
}