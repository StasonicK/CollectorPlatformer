using CodeBase.Progress;
using CodeBase.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private const string ProgressKey = "Progress";

        public SaveLoadService(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress() =>
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());

        public PlayerProgress LoadProgress()
        {
            PlayerProgress progress = PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
            return progress;
        }

        public void ClearProgress() =>
            _progressService.SetPlayerProgress(new PlayerProgress());
    }
}