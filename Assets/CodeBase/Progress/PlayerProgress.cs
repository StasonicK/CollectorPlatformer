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
        private List<LevelId> _allLevelIds = Enum.GetValues(typeof(LevelId)).Cast<LevelId>().ToList();
        private Dictionary<LevelId, LevelData> _levelsProgress = new Dictionary<LevelId, LevelData>();
        private int _currentLevelIndex;
        private int _initialIndex = 1;

        public LevelData CurrentLevelData;
        public LevelId CurrentLevelId;
        public LevelId NextLevelId;

        public event Action CurrentLevelDataChanged;

        public void Initialize()
        {
            _currentLevelIndex = _initialIndex;

            SetCurrentLevelIdData();
            SetNextLevelId();
        }

        private void SetNextLevelId()
        {
            int nextLevelIndex = _currentLevelIndex + 1;
            NextLevelId = CheckLevelIndex(nextLevelIndex) ? _allLevelIds[nextLevelIndex] : LevelId.Empty;
        }

        public void UpLevel()
        {
            SaveCurrentLevelData();
            _currentLevelIndex++;
            SetCurrentLevelIdData();
            SetNextLevelId();
        }

        private void SetCurrentLevelIdData()
        {
            CurrentLevelId = _allLevelIds[_currentLevelIndex];
            CurrentLevelData = new LevelData();
        }

        private bool CheckLevelIndex(int index) =>
            _allLevelIds.Count > index;

        public void IncreaseCollectedCount()
        {
            CurrentLevelData.CollectedMedalsCount++;
            CurrentLevelDataChanged?.Invoke();
        }

        public void InitCurrentLevelData(int maxCount)
        {
            CurrentLevelData.CollectedMedalsCount = 0;
            CurrentLevelData.AllMedalsCount = maxCount;
            CurrentLevelDataChanged?.Invoke();
        }

        public void SetMedalSprite(Sprite medalSprite) =>
            CurrentLevelData.MedalSprite = medalSprite;

        private void SaveCurrentLevelData() =>
            _levelsProgress[CurrentLevelId] = CurrentLevelData;

        public void ClearCurrentLevelData() =>
            CurrentLevelData = new LevelData();
    }
}