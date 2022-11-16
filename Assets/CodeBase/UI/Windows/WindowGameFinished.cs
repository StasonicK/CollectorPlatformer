using CodeBase.Progress;
using CodeBase.Services;
using CodeBase.Services.Levels;
using CodeBase.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class WindowGameFinished : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Image _image;

        private ILevelLoader _levelLoader;
        private IPersistentProgressService _progressService;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
            _newGameButton.onClick.AddListener(ToNewGame);
            _levelLoader = AllServices.Container.Single<ILevelLoader>();
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
        }

        public void Construct(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        private void RestartLevel()
        {
            _levelLoader.RestartLevel();
            Time.timeScale = 1;
            Destroy(gameObject);
        }

        private void ToNewGame()
        {
            _progressService.SetPlayerProgress(new PlayerProgress());
            _levelLoader.RestartLevel();
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}