using CodeBase.Services;
using CodeBase.Services.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class WindowLevelFinished : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Image _image;

        private ILevelLoader _levelLoader;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
            _nextLevelButton.onClick.AddListener(ToNextLevel);
            _levelLoader = AllServices.Container.Single<ILevelLoader>();
        }

        public void Construct(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        private void RestartLevel()
        {
            _levelLoader.RestartLevel();
            Destroy(gameObject);
        }

        private void ToNextLevel()
        {
            _levelLoader.NextLevel();
            Destroy(gameObject);
        }
    }
}