using CodeBase.Progress;
using CodeBase.Services;
using CodeBase.Services.Levels;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.SaveLoad;
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
        private ISaveLoadService _saveLoadService;
        private IPersistentProgressService _progressService;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
            _newGameButton.onClick.AddListener(ToNewGame);
            _levelLoader = AllServices.Container.Single<ILevelLoader>();
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
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

        private void ToNewGame()
        {
            PlayerProgress playerProgress = new PlayerProgress();
            playerProgress.Initialize();
            _progressService.SetPlayerProgress(playerProgress);
            _saveLoadService.SaveProgress();
            _levelLoader.RestartLevel();
            Destroy(gameObject);
        }
    }
}