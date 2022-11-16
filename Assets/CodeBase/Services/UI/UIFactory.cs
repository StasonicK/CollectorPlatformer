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
        private GameObject _hudCounterGameObject;

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
            if (_hudCounterGameObject == null)
                _hudCounterGameObject = await Addressables.InstantiateAsync(AddressablePaths.Hud, _rootUI).Task;

            GameObject _amuletsCounterGameObject = _hudCounterGameObject.transform.GetChild(0).gameObject;
            _amuletsCounter = _amuletsCounterGameObject.GetComponent<AmuletsCounter>();
            _amuletsCounter.Construct(_progressService);
            LevelId currentLevelId = _progressService.Progress.CurrentLevelId;
            _currentLevelStaticData = _staticDataService.ForLevel(currentLevelId);
            _amuletsCounter.InitializeCounter(_currentLevelStaticData.MaxAmuletsCount);
            Object.Instantiate(_amuletsCounterGameObject, _rootUI.transform);
        }
    }
}