using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;
using UnityEngine;

namespace CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataLevelsPath = "StaticData/Levels";
        private const string StaticDataWindowsPath = "StaticData/Windows";

        private Dictionary<LevelId, LevelStaticData> _levels;
        private Dictionary<WindowId, WindowStaticData> _windows;

        public void Load()
        {
            _levels = Resources
                .LoadAll<LevelStaticData>(StaticDataLevelsPath)
                .ToDictionary(x => x.LevelId, x => x);

            _windows = Resources
                .LoadAll<WindowStaticData>(StaticDataWindowsPath)
                .ToDictionary(x => x.WindowId, x => x);
        }

        public LevelStaticData ForLevel(LevelId levelId) =>
            _levels.TryGetValue(levelId, out LevelStaticData staticData)
                ? staticData
                : null;

        public WindowStaticData ForWindow(WindowId windowId) =>
            _windows.TryGetValue(windowId, out WindowStaticData windowData)
                ? windowData
                : null;
    }
}