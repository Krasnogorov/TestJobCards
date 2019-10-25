using Controllers;
using Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        /// collection of sprites
        [SerializeField]
        private ImageCollection _imageCollection = null;
        /// swipes count label
        [SerializeField]
        private Text _swipeCountLabel = null;
        /// index of selected image
        private int _selectedIndex = 0;
        /// count of swipes
        private int _swipesCount = 0;
        /// list with unused indexes of picture
        public List<int> _unusedIndexes = new List<int>();

        /// key of selected index
        private const string SELECTED_INDEX_KEY = "selected_key";
        /// key of count of swipes
        private const string SWIPE_COUNT_KEY = "swipe_count_key";
        /// count of shuffles
        private const int SHUFFLE_COUNT = 3;
        
        private void Start()
        {
            _selectedIndex = SaveManager.Instance.GetIntForKey(SELECTED_INDEX_KEY, 0);
            _swipesCount = SaveManager.Instance.GetIntForKey(SWIPE_COUNT_KEY, 0);
            ShowImage();
            _swipeCountLabel.text = _swipesCount.ToString();
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
        private void ShowImage(bool isRandom = false)
        {
            int index = isRandom ? GetNextIndex() : _selectedIndex;
            SaveManager.Instance.SetIntForKey(SELECTED_INDEX_KEY, index);
            _swipeImage.DisplayImage(_imageCollection.GetItem(index), (result) =>
            {
                if (result)
                {
                    UpdateSwipes();

                    ShowImage(true);

                }
            });
        }

        private int GetNextIndex()
        {
            int ret = 0;
            if (_unusedIndexes.Count == 0)
            {
                GenerateIndexesList();                
            }
            ret = _unusedIndexes[Random.Range(0, _unusedIndexes.Count - 1)];
            _unusedIndexes.Remove(ret);
            return ret;
        }

        private void GenerateIndexesList()
        {
            _unusedIndexes = Enumerable.Range(0, _imageCollection.Length - 1).ToList();
            // shuffle this list
            int count = _unusedIndexes.Count;
            for (int i = 0; i < SHUFFLE_COUNT; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    int randIndex = Random.Range(0, count);
                    int tmp = _unusedIndexes[j];
                    _unusedIndexes[j] = _unusedIndexes[randIndex];
                    _unusedIndexes[randIndex] = tmp;
                }
            }
        }
        private void UpdateSwipes()
        {
            _swipesCount++;
            SaveManager.Instance.SetIntForKey(SWIPE_COUNT_KEY, _swipesCount);

            _swipeCountLabel.text = _swipesCount.ToString();
        }
    }
}