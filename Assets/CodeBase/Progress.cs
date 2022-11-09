using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBase
{
    [Serializable]
    public class Progress
    {
        private List<string> AllLevels;

        public string CurrentLevel { get; private set; }
        public string NextLevel { get; private set; }


        public Progress()
        {
            List<Level.Level> allLevels = Enum.GetValues(typeof(Level.Level)).Cast<Level.Level>().ToList();

            foreach (Level.Level level in allLevels)
                AllLevels.Add(level.ToString());

            CurrentLevel = AllLevels[0];
            int currentLevelIndex = FindIndex();

            NextLevel = CheckLevelIndex(++currentLevelIndex) ? AllLevels[1] : null;
        }

        public void ChangeLevel()
        {
            int currentLevelIndex = FindIndex();
            CurrentLevel = AllLevels[++currentLevelIndex];
            NextLevel = AllLevels[currentLevelIndex + 2];
        }

        private int FindIndex() =>
            AllLevels.FindIndex(x => x == CurrentLevel);

        private bool CheckLevelIndex(int index)
        {
            if (AllLevels.Count < index)
                return true;
            else
                return false;
        }
    }
}