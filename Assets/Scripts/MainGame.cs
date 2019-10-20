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
        /// list of images and texts
        [SerializeField]
        private List<ImageData> _images = new List<ImageData>();
        /// index of selected image
        private int _selectedIndex = 0;
        /// key of selected index
        private const string SELECTED_INDEX_KEY = "selected_key";

        private void Start()
        {
            _selectedIndex = PlayerPrefs.GetInt(SELECTED_INDEX_KEY, 0);
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

        private void OnBackButtonClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }
        /// <summary>
        /// Display current image
        /// </summary>
        private void ShowImage()
        {
            _swipeImage.DisplayImage(_images[_selectedIndex], (result) =>
            {
                if (result)
                {
                    _selectedIndex++;
                    if (_selectedIndex >= _images.Count)
                    {
                        _selectedIndex = 0;
                    }
                    PlayerPrefs.SetInt(SELECTED_INDEX_KEY, _selectedIndex);
                    PlayerPrefs.Save();
                    ShowImage();
                }
            });
        }
    }
}