using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class WindowLevelRestart : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private GameObject _level;

        private void Awake()
        {
            _restartLevelButton.onClick.AddListener(RestartLevel);
        }

        private void RestartLevel()
        {
            Destroy(_level);
            Instantiate(_level);
            Destroy(this);
        }
    }
}