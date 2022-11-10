using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Levels;
using UnityEngine;

namespace CodeBase.Progress
{
    [Serializable]
    public class PlayerProgress
    {
        private List<LevelId> _allLevelIds;
        private Dictionary<LevelId, LevelData> _levelsProgress = new Dictionary<LevelId, LevelData>();

        public LevelData CurrentLevelData { get; private set; }
        public LevelId CurrentLevelId { get; private set; }
        public LevelId NextLevelId { get; private set; }

        public Action CurrentLevelDataChanged;

        public PlayerProgress()
        {
            _allLevelIds = Enum.GetValues(typeof(LevelId)).Cast<LevelId>().ToList();

            for (int i = 1; i < _allLevelIds.Count; i++)
                _levelsProgress[_allLevelIds[i]] = new LevelData();

            CurrentLevelId = _allLevelIds[1];
            int currentLevelIndex = FindIndex();
            CurrentLevelData = _levelsProgress[CurrentLevelId];

            NextLevelId = CheckLevelIndex(++currentLevelIndex) ? _allLevelIds[1] : LevelId.Empty;
        }

        public void UpLevel()
        {
            int currentLevelIndex = FindIndex();
            CurrentLevelId = _allLevelIds[++currentLevelIndex];
            CurrentLevelData = _levelsProgress[CurrentLevelId];
            NextLevelId = _allLevelIds[currentLevelIndex + 2];
        }

        private int FindIndex() =>
            _allLevelIds.FindIndex(x => x == CurrentLevelId);

        private bool CheckLevelIndex(int index)
        {
            if (_allLevelIds.Count - 1 <= index)
                return true;
            else
                return false;
        }

        public void IncreaseCollectedCount()
        {
            CurrentLevelData.CollectedMedalsCount++;
            CurrentLevelDataChanged?.Invoke();
        }

        public void InitCurrentLevelData(int maxCount)
        {
            CurrentLevelData.CollectedMedalsCount = 0;
            CurrentLevelData.AllMedalsCount = maxCount;
        }

        public void SetMedalSprite(Sprite medalSprite) =>
            CurrentLevelData.MedalSprite = medalSprite;

        public LevelData GetCurrentLevelData() =>
            _levelsProgress[CurrentLevelId];

        public void SaveCurrentLevelData() =>
            _levelsProgress[CurrentLevelId] = CurrentLevelData;
    }
}