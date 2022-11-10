using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Medals;
using CodeBase.StaticData.Windows;
using UnityEngine;

namespace CodeBase.Services
{
    public class StaticDataService
    {
        private const string StaticDataLevelsPath = "StaticData/Levels";
        private const string StaticDataWindowsPath = "StaticData/Windows";
        private const string StaticDataMedalsPath = "StaticData/Medals";

        private Dictionary<LevelId, LevelStaticData> _levels;
        private Dictionary<WindowId, WindowStaticData> _windows;
        private Dictionary<MedalId, MedalStaticData> _medals;

        public void Load()
        {
            _levels = Resources
                .LoadAll<LevelStaticData>(StaticDataLevelsPath)
                .ToDictionary(x => x.LevelId, x => x);

            _windows = Resources
                .LoadAll<WindowStaticData>(StaticDataWindowsPath)
                .ToDictionary(x => x.WindowId, x => x);

            _medals = Resources
                .LoadAll<MedalStaticData>(StaticDataMedalsPath)
                .ToDictionary(x => x.MedalId, x => x);
        }


        public LevelStaticData ForLevel(LevelId levelId) =>
            _levels.TryGetValue(levelId, out LevelStaticData staticData)
                ? staticData
                : null;

        public WindowStaticData ForWindow(WindowId windowId) =>
            _windows.TryGetValue(windowId, out WindowStaticData windowData)
                ? windowData
                : null;

        public MedalStaticData ForMedal(MedalId medalId) =>
            _medals.TryGetValue(medalId, out MedalStaticData medalData)
                ? medalData
                : null;
    }
}