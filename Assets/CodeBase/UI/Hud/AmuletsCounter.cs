using CodeBase.Progress;
using CodeBase.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Hud
{
    public class AmuletsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _collectedAmulets;
        [SerializeField] private TextMeshProUGUI _allAmulets;

        private LevelData _currentLevelData;
        private IPersistentProgressService _progressService;

        public void Construct(IPersistentProgressService progressService)
        {
            _progressService = progressService;
            _currentLevelData = progressService.Progress.CurrentLevelData;

            progressService.Progress.CurrentLevelDataChanged += UpdateCounter;
        }

        public void InitializeCounter(int maxCount) =>
            _progressService.Progress.InitCurrentLevelData(maxCount);

        private void UpdateCounter()
        {
            _collectedAmulets.text = _currentLevelData.CollectedMedalsCount.ToString();
            _allAmulets.text = _currentLevelData.AllMedalsCount.ToString();
        }
    }
}