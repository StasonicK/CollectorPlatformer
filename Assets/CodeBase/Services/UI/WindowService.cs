using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.Services.UI
{
    public class WindowService : IWindowService
    {
        private IStaticDataService _staticDataService;
        private IUIFactory _uiFactory;
        private IPersistentProgressService _progressService;

        public WindowService(IStaticDataService staticDataService, IUIFactory uiFactory, IPersistentProgressService progressService)
        {
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _progressService = progressService;
        }

        public void CreateWindow(WindowId windowId)
        {
            WindowStaticData windowStaticData = _staticDataService.ForWindow(windowId);
            GameObject window = Object.Instantiate(windowStaticData.Prefab, _uiFactory.GetRootUI().transform);

            switch (windowId)
            {
                case WindowId.LevelFinished:
                    WindowLevelFinished windowLevelFinished = window.GetComponent<WindowLevelFinished>();
                    windowLevelFinished.Construct(_progressService.Progress.CurrentLevelData.MedalSprite);
                    Time.timeScale = 0;
                    break;
                case WindowId.GameFinished:
                    WindowGameFinished windowGameFinished = window.GetComponent<WindowGameFinished>();
                    windowGameFinished.Construct(_progressService.Progress.CurrentLevelData.MedalSprite);
                    Time.timeScale = 0;
                    break;
                case WindowId.LevelRestart:
                    window.GetComponent<WindowLevelRestart>();
                    Time.timeScale = 0;
                    break;
            }
        }
    }
}