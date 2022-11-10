using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Levels;

namespace CodeBase.Progress
{
    [Serializable]
    public class PlayerProgress
    {
        private List<LevelId> _allLevels;
        private Dictionary<LevelId, LevelData> _levelsProgress;

        public LevelData CurrentLevelData { get; private set; }
        public LevelId CurrentLevelId { get; private set; }
        public LevelId NextLevelId { get; private set; }

        public PlayerProgress()
        {
            _allLevels = Enum.GetValues(typeof(LevelId)).Cast<LevelId>().ToList();

            CurrentLevelId = _allLevels[1];
            int currentLevelIndex = FindIndex();
            CurrentLevelData = _levelsProgress[CurrentLevelId];

            NextLevelId = CheckLevelIndex(++currentLevelIndex) ? _allLevels[1] : LevelId.Empty;
        }

        public void UpLevel()
        {
            int currentLevelIndex = FindIndex();
            CurrentLevelId = _allLevels[++currentLevelIndex];
            NextLevelId = _allLevels[currentLevelIndex + 2];
        }

        private int FindIndex() =>
            _allLevels.FindIndex(x => x == CurrentLevelId);

        private bool CheckLevelIndex(int index)
        {
            if (_allLevels.Count - 1 <= index)
                return true;
            else
                return false;
        }

        public LevelData GetCurrentLevelData() =>
            _levelsProgress[CurrentLevelId];

        public void SetCurrentLevelData(LevelData levelData) =>
            _levelsProgress[CurrentLevelId] = levelData;
    }
}