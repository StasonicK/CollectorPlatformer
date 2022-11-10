using CodeBase.Progress;
using UnityEngine;

namespace CodeBase.Services
{
    public class SaveLoadService
    {
        private const string ProgressKey = "Progress";

        public ProgressService ProgressService { get; private set; }

        public SaveLoadService(ProgressService progressService)
        {
            ProgressService = progressService;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKey, ProgressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();
    }
}