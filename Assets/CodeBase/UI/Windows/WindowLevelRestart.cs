using CodeBase.Services;
using CodeBase.Services.Levels;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class WindowLevelRestart : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;

        private ILevelLoader _levelLoader;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
            _levelLoader = AllServices.Container.Single<ILevelLoader>();
        }

        private void RestartLevel()
        {
            _levelLoader.RestartLevel();
            Destroy(gameObject);
        }
    }
}