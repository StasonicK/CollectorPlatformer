using CodeBase.Progress;
using UnityEngine;

namespace CodeBase.Services
{
    public class SaveLoadService
    {
        private const string ProgressKey = "Progress";

        public PlayerProgress Progress { get; private set; }
        // public ProgressService ProgressService { get; private set; }

        public SaveLoadService(PlayerProgress progress)
        {
            Progress = progress;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKey, Progress.ToJson());
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
    }
}