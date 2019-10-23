using Controllers;
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class for control main game interface
    /// </summary>
    public class MainGame : MonoBehaviour
    {
        /// link to back button
        [SerializeField]
        private Button _backButton = null;
        /// link to swipe image
        [SerializeField]
        private SwipeImage _swipeImage = null;
        
        [SerializeField]
        private ImageCollection _imageCollection = null;

        /// index of selected image
        private int _selectedIndex = 0;
        /// key of selected index
        private const string SELECTED_INDEX_KEY = "selected_key";

        private void Start()
        {
            _selectedIndex = SaveManager.Instance.GetIntForKey(SELECTED_INDEX_KEY, 0);
            ShowImage();
        }

        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
        }
        /// <summary>
        /// Callback for back button
        /// </summary>
        private void OnBackButtonClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }
        /// <summary>
        /// Display current image
        /// </summary>
        private void ShowImage()
        {
            if (_selectedIndex >= _imageCollection.Length)
            {
                _selectedIndex = 0;
            }
            _swipeImage.DisplayImage(_imageCollection.GetItem(_selectedIndex), (result) =>
            {
                if (result)
                {
                    _selectedIndex++;
                    if (_selectedIndex >= _imageCollection.Length)
                    {
                        _selectedIndex = 0;
                    }
                    SaveManager.Instance.SetIntForKey(SELECTED_INDEX_KEY, _selectedIndex);
                    ShowImage();
                }
            });
        }
    }
}