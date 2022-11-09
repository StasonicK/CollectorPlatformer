using System;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private GameObject _restartLevelWindow;

        public Action Died;

        private void Awake()
        {
            Died += ShowLevelRestartWindow;
        }

        private void ShowLevelRestartWindow()
        {
            Time.timeScale = 0;
            Instantiate(_restartLevelWindow);
        }
    }
}