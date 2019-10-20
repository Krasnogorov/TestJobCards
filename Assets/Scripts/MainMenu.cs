using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class controls events in main mmenu
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        /// link to animated cube
        [SerializeField]
        private GameObject _cube = null;
        /// link to settings button
        [SerializeField]
        private Button _settingsButton = null;
        /// link to achievement button
        [SerializeField]
        private Button _achievementButton = null;
        /// link to about button
        [SerializeField]
        private Button _aboutButton = null;

        private void OnEnable()
        {
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _achievementButton.onClick.AddListener(OnAchievementButtonClicked);
            _aboutButton.onClick.AddListener(OnAboutButtonClicked);
        }

        private void OnDisable()
        {
            _settingsButton.onClick.RemoveAllListeners();
            _achievementButton.onClick.RemoveAllListeners();
            _aboutButton.onClick.RemoveAllListeners();
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject == _cube)
                    {
                        SceneManager.LoadScene("MainGame");
                    }
                }
            }
        }
        /// <summary>
        /// Callback for settings button
        /// </summary>
        private void OnSettingsButtonClicked()
        {
            Debug.LogError("Setiings button clicked");
        }
        /// <summary>
        /// Callback for achievement button
        /// </summary>
        private void OnAchievementButtonClicked()
        {
            Debug.LogError("Achievement button clicked");
        }
        /// <summary>
        /// Link to about button
        /// </summary>
        private void OnAboutButtonClicked()
        {
            Debug.LogError("About button clicked");
        }
    }
}