using CodeBase.Services;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class WindowLevelRestart : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
        }

        public void Construct(LevelLoader levelLoader)
        {
        }

        private void RestartLevel()
        {
            // Destroy(_level);
            // Instantiate(_level);
            Destroy(this);
        }
    }
}