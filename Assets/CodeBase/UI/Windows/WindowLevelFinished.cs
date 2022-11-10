using CodeBase.Services;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class WindowLevelFinished : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Image _image;

        private GameObject _level;
        private GameObject _nextlevel;

        private string _nextLevelName;
        private LevelLoader _levelLoader;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
            _nextLevelButton.onClick.AddListener(ToNextLevel);
        }

        public void Construct(Sprite sprite, LevelLoader levelLoader)
        {
            _image.sprite = sprite;
            _levelLoader = levelLoader;
        }

        private void RestartLevel()
        {
            _levelLoader.RestartLevel?.Invoke();
            Destroy(this);
        }

        private void ToNextLevel()
        {
            _levelLoader.ToNextLevel?.Invoke();
            Destroy(this);
        }
    }
}