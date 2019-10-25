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
        /// left swipes count label
        [SerializeField]
        private Text _swipeToLeftCountLabel = null;
        /// rightswipes count label
        [SerializeField]
        private Text _swipeToRightCountLabel = null;
        /// index of selected image
        private int _selectedIndex = 0;
        /// count of swipes to left
        private int _swipesToLeftCount = 0;
        /// count of swipes to right
        private int _swipesToRightCount = 0;
        /// list with unused indexes of picture
        public List<int> _unusedIndexes = new List<int>();

        /// key of selected index
        private const string SELECTED_INDEX_KEY = "selected_key";
        /// key of count of swipes to left
        private const string LEFT_SWIPE_COUNT_KEY = "left_swipe_count_key";
        /// key of count of swipes to right
        private const string RIGHT_SWIPE_COUNT_KEY = "right_swipe_count_key";
        /// count of shuffles
        private const int SHUFFLE_COUNT = 3;
        
        private void Start()
        {
            _selectedIndex = SaveManager.Instance.GetIntForKey(SELECTED_INDEX_KEY, 0);
            _swipesToLeftCount = SaveManager.Instance.GetIntForKey(LEFT_SWIPE_COUNT_KEY, 0);
            _swipesToRightCount = SaveManager.Instance.GetIntForKey(RIGHT_SWIPE_COUNT_KEY, 0);
            ShowImage();
            _swipeToLeftCountLabel.text = _swipesToLeftCount.ToString();
            _swipeToRightCountLabel.text = _swipesToRightCount.ToString();
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
            _swipeImage.DisplayImage(_imageCollection.GetItem(index), (result, direction) =>
            {
                if (result)
                {
                    UpdateSwipes(direction);

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
        private void UpdateSwipes(SwipeDirection direction)
        {
            if (direction == SwipeDirection.Left)
            {
                _swipesToLeftCount++;
                SaveManager.Instance.SetIntForKey(LEFT_SWIPE_COUNT_KEY, _swipesToLeftCount);

                _swipeToLeftCountLabel.text = _swipesToLeftCount.ToString();
            }
            else if (direction == SwipeDirection.Right)
            {
                _swipesToRightCount++;
                SaveManager.Instance.SetIntForKey(RIGHT_SWIPE_COUNT_KEY, _swipesToRightCount);

                _swipeToRightCountLabel.text = _swipesToRightCount.ToString();
            }
            
        }
    }
}