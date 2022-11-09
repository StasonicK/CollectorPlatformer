using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class WindowLevelFinished : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _level;
        [SerializeField] private GameObject _nextlevel;

        private string _nextLevelName;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
            _nextLevelButton.onClick.AddListener(ToNextLevel);
        }

        public void Construct(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        private void RestartLevel()
        {
            Destroy(_level);
            Instantiate(_level);
        }

        private void ToNextLevel()
        {
            Destroy(_level);
            Instantiate(_nextlevel);
        }
    }
}