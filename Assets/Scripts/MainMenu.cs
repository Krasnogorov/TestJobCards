using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Class controls events in main mmenu
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _cube = null;
        [SerializeField]
        private Button _settingsButton = null;
        [SerializeField]
        private Button _achievementButton = null;
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
                        Debug.LogError("Click on cube");
                    }
                }
            }
        }
        private void OnSettingsButtonClicked()
        {
            Debug.LogError("Setiings button clicked");
        }

        private void OnAchievementButtonClicked()
        {
            Debug.LogError("Achievement button clicked");
        }

        private void OnAboutButtonClicked()
        {
            Debug.LogError("About button clicked");
        }
    }
}