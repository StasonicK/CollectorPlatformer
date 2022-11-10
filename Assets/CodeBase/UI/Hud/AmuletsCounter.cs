using CodeBase.Progress;
using CodeBase.Services;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Hud
{
    public class AmuletsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _collectedAmulets;
        [SerializeField] private TextMeshProUGUI _allAmulets;

        private SaveLoadService _saveLoadService;

        public void Construct(Sprite sprite, SaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;

            LevelData levelData = _saveLoadService.ProgressService.Progress.GetCurrentLevelData();
            _collectedAmulets.text = levelData.CollectedMedalsCount.ToString();
            _allAmulets.text = levelData.AllMedalsCount.ToString();
        }
    }
}