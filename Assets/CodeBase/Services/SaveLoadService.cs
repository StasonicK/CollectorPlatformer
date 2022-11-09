using UnityEngine;

namespace CodeBase.Services
{
    public class SaveLoadService
    {
        private const string ProgressKey = "Progress";

        private ProgressService _progressService;

        public SaveLoadService(ProgressService progressService)
        {
            _progressService = progressService;
        }

        public void SaveProgress()
        {
            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public Progress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<Progress>();
    }
}