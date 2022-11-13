using System;
using CodeBase.Progress;
using CodeBase.Services.Input;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;
using CodeBase.UI;
using CodeBase.UI.Hud;
using UnityEngine;

namespace CodeBase.Services
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private LoadingCurtain _curtain;
        [SerializeField] private GameObject _amuletsCounterGameObject;
        [SerializeField] private GameObject _mobileInputGameObject;
        [SerializeField] private Sprite _goldMedalSprite;
        [SerializeField] private Sprite _silverMedalSprite;

        public GameObject RootUIGameObject;
        
        private GameObject _currentLevelGameObject;
        private LevelStaticData _currentLevelStaticData;
        private StaticDataService _staticDataService;
        private SaveLoadService _saveLoadService;
        private PlayerProgress _playerProgress;
        private AmuletsCounter _amuletsCounter;

        public Action ToNextLevel;
        public Action RestartLevel;

        private void Awake()
        {
            _staticDataService = new StaticDataService();
            _staticDataService.Load();
            _saveLoadService = new SaveLoadService(new PlayerProgress());

            ToNextLevel += LaunchNextLevel;
            RestartLevel += LaunchRestartLevel;

            LoadProgressOrInitNew();

            CreateLevel();
            CreateUI();

            DontDestroyOnLoad(this);
        }

        public void SetMedal()
        {
            Sprite medalSprite = _playerProgress.CurrentLevelData.CollectedMedalsCount < _playerProgress.CurrentLevelData.AllMedalsCount
                ? _silverMedalSprite
                : _goldMedalSprite;

            _playerProgress.SetMedalSprite(medalSprite);
        }

        public void CreateWindow(WindowId windowId)
        {
            WindowStaticData windowStaticData = _staticDataService.ForWindow(windowId);
            GameObject window = Instantiate(windowStaticData.Prefab, RootUIGameObject.transform);

            switch (windowId)
            {
                case WindowId.LevelFinished:
                    WindowLevelFinished windowLevelFinished = window.GetComponent<WindowLevelFinished>();
                    windowLevelFinished.Construct(_playerProgress.CurrentLevelData.MedalSprite, this);
                    break;
                case WindowId.LevelRestart:
                    WindowLevelRestart windowLevelRestart = window.GetComponent<WindowLevelRestart>();
                    windowLevelRestart.Construct(this);
                    break;
            }
        }

        private void CreateUI()
        {
            CreateAmuletCounter();

            MobileInput mobileInput = _mobileInputGameObject.GetComponent<MobileInput>();
        }

        private void CreateAmuletCounter()
        {
            _amuletsCounter = _amuletsCounterGameObject.GetComponent<AmuletsCounter>();
            Instantiate(_amuletsCounterGameObject, RootUIGameObject.transform);
            _amuletsCounter.Construct(_saveLoadService);
            _amuletsCounter.InitializeCounter(_currentLevelStaticData.MaxAmuletsCount);
            _playerProgress.CurrentLevelDataChanged += UpdateCounter;
        }

        private void UpdateCounter() =>
            _amuletsCounter.UpdateCounter();

        private void LaunchRestartLevel()
        {
            ShowLoadingCurtain();
            Destroy(_currentLevelGameObject);
            CreateLevel();
            HideLoadingCurtain();
        }

        private void LaunchNextLevel()
        {
            SaveResult();
            ShowLoadingCurtain();
            Destroy(_currentLevelGameObject);
            CreateLevel();
            HideLoadingCurtain();
        }

        private void SaveResult()
        {
            _playerProgress.SaveCurrentLevelData();
            _playerProgress.UpLevel();
            _saveLoadService.SaveProgress();
        }

        private void ShowLoadingCurtain() =>
            _curtain.Show?.Invoke();

        private void HideLoadingCurtain() =>
            _curtain.Hide?.Invoke();

        private void LoadProgressOrInitNew() =>
            _playerProgress = _saveLoadService.LoadProgress() ?? new PlayerProgress();

        private void CreateLevel()
        {
            LevelId currentLevelId = _playerProgress.CurrentLevelId;
            _currentLevelStaticData = _staticDataService.ForLevel(currentLevelId);
            _currentLevelGameObject = _currentLevelStaticData.Prefab;
            Instantiate(_currentLevelGameObject);
        }
    }
}