using CodeBase.Hero;
using CodeBase.Services;
using CodeBase.Services.Levels;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.UI;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;
using UnityEngine;

namespace CodeBase.Level
{
    public class LevelFinishedTrigger : MonoBehaviour
    {
        private IWindowService _windowService;
        private ILevelLoader _levelLoader;
        private IPersistentProgressService _progressService;

        private void Awake()
        {
            _windowService = AllServices.Container.Single<IWindowService>();
            _levelLoader = AllServices.Container.Single<ILevelLoader>();
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<HeroMovement>(out HeroMovement hero))
            {
                _levelLoader.SetMedal();

                bool isNextLevelEmpty = _progressService.Progress.NextLevelId == LevelId.Empty;

                _windowService.CreateWindow(isNextLevelEmpty ? WindowId.GameFinished : WindowId.LevelFinished);
            }
        }
    }
}