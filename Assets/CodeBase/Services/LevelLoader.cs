using System;
using CodeBase.Progress;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Medals;
using CodeBase.StaticData.Windows;
using CodeBase.UI;
using CodeBase.UI.Hud;
using UnityEngine;

namespace CodeBase.Services
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private LoadingCurtain _curtain;

        [SerializeField] private AmuletsCounter _amuletsCounter;
        // [SerializeField] private LoadingCurtain _curtain;

        public GameObject RootUI;
        private GameObject _currentLevel;

        private StaticDataService _staticDataService;
        private SaveLoadService _saveLoadService;
        private ProgressService _progressService;

        public Action ToNextLevel;
        public Action RestartLevel;

        private void Awake()
        {
            _staticDataService = new StaticDataService();
            _progressService = new ProgressService();
            _saveLoadService = new SaveLoadService(_progressService);

            ToNextLevel += LaunchNextLevel;
            RestartLevel += LaunchRestartLevel;

            LoadProgressOrInitNew();

            CreateLevel();
            CreateUI();

            DontDestroyOnLoad(this);
        }

        private void CreateUI()
        {
        }

        private void LaunchRestartLevel()
        {
            ShowLoadingCurtain();
            Destroy(_currentLevel);
            CreateLevel();
            HideLoadingCurtain();
        }

        private void LaunchNextLevel()
        {
            SaveResult();
            ShowLoadingCurtain();
            Destroy(_currentLevel);
            CreateLevel();
            HideLoadingCurtain();
        }

        private void SaveResult()
        {
            _saveLoadService.ProgressService.Progress.UpLevel();
            _saveLoadService.SaveProgress();
        }

        private void ShowLoadingCurtain() =>
            _curtain.Show?.Invoke();

        private void HideLoadingCurtain() =>
            _curtain.Hide?.Invoke();

        private void LoadProgressOrInitNew() =>
            _progressService.Progress = _saveLoadService.LoadProgress() ?? new PlayerProgress();

        private void CreateLevel()
        {
            LevelId currentLevelId = _saveLoadService.ProgressService.Progress.CurrentLevelId;
            LevelStaticData levelStaticData = _staticDataService.ForLevel(currentLevelId);
            _currentLevel = levelStaticData.Prefab;
            Instantiate(_currentLevel);
        }

        private void CreateWindow(WindowId windowId)
        {
            WindowStaticData windowStaticData = _staticDataService.ForWindow(windowId);
            GameObject window = Instantiate(windowStaticData.Prefab, RootUI.transform);

            switch (windowId)
            {
                case WindowId.LevelFinished:
                    WindowLevelFinished windowLevelFinished = window.GetComponent<WindowLevelFinished>();
                    // MedalStaticData medalStaticData = _staticDataService.ForMedal();
                    // Sprite medalSprite = windowStaticData.
                    windowLevelFinished.Construct(_progressService.Progress.GetCurrentLevelData().MedalSprite, this);
                    break;
                case WindowId.LevelRestart:
                    WindowLevelRestart windowLevelRestart = window.GetComponent<WindowLevelRestart>();
                    windowLevelRestart.Construct(this);
                    break;
            }
        }
    }
}