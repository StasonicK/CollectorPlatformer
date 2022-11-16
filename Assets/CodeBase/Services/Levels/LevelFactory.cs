using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Services.Levels
{
    class LevelFactory : ILevelFactory
    {
        private LevelStaticData _currentLevelStaticData;
        private IStaticDataService _staticDataService;
        private IPersistentProgressService _progressService;

        public LevelFactory(IStaticDataService staticDataService, IPersistentProgressService progressService)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
        }

        public GameObject CreateLevel()
        {
            LevelId currentLevelId = _progressService.Progress.CurrentLevelId;
            _currentLevelStaticData = _staticDataService.ForLevel(currentLevelId);
            return _currentLevelStaticData.Prefab;
        }
    }
}