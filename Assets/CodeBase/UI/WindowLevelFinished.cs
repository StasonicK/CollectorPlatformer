using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class WindowLevelFinished : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _nextLevelButton;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
            _nextLevelButton.onClick.AddListener(ToNextLevel);
        }

        private void RestartLevel()
        {
            
        }

        private void ToNextLevel()
        {
            
        }
    }
}