using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Hud;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Services.UI
{
    public class UIFactory : IUIFactory
    {
        private GameObject _amuletsCounterGameObject;
        private GameObject _controlsCounterGameObject;

        private IPersistentProgressService _progressService;
        private IStaticDataService _staticDataService;
        private Transform _rootUI;
        private AmuletsCounter _amuletsCounter;

        private LevelStaticData _currentLevelStaticData;

        public UIFactory(IPersistentProgressService progressService, IStaticDataService staticDataService, Transform rootUI)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _rootUI = rootUI;
        }

        public Transform GetRootUI() =>
            _rootUI.transform;

        public async void CreateAmuletCounter()
        {
            if (_amuletsCounterGameObject == null)
                _amuletsCounterGameObject = await Addressables.InstantiateAsync(AddressablePaths.Amulets, _rootUI).Task;

            _amuletsCounter = _amuletsCounterGameObject.GetComponent<AmuletsCounter>();
            _amuletsCounter.Construct(_progressService);
            LevelId currentLevelId = _progressService.Progress.CurrentLevelId;
            _currentLevelStaticData = _staticDataService.ForLevel(currentLevelId);
            _amuletsCounter.InitializeCounter(_currentLevelStaticData.MaxAmuletsCount);
        }

        public async void CreateControls(GameObject hero)
        {
            if (_controlsCounterGameObject == null)
                _controlsCounterGameObject = await Addressables.InstantiateAsync(AddressablePaths.Controls, _rootUI).Task;
        }
    }
}