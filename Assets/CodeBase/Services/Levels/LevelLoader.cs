﻿using CodeBase.Hero;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.SaveLoad;
using CodeBase.Services.UI;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Services.Levels
{
    public class LevelLoader : ILevelLoader
    {
        private Sprite _silverMedalSprite;
        private Sprite _goldMedalSprite;
        private LoadingCurtain _curtain;
        private GameObject _currentLevelGameObject;
        private GameObject _heroGameObject;

        private ILevelFactory _levelFactory;
        private IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private IUIFactory _uiFactory;

        public LevelLoader(Sprite silverMedalSprite, Sprite goldMedalSprite, LoadingCurtain curtain, ILevelFactory levelFactory,
            IPersistentProgressService progressService, ISaveLoadService saveLoadService, IUIFactory uiFactory)
        {
            _silverMedalSprite = silverMedalSprite;
            _goldMedalSprite = goldMedalSprite;
            _curtain = curtain;
            _levelFactory = levelFactory;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _uiFactory = uiFactory;
        }

        public GameObject GetHeroGameObject() =>
            _heroGameObject;

        public void NextLevel()
        {
            ShowLoadingCurtain();
            SaveResult();
            DestroyLevel();
            DestroyHero();
            CreateLevelHero();
            HideLoadingCurtain();
            Time.timeScale = 1;
        }

        public void RestartLevel()
        {
            ShowLoadingCurtain();
            ClearResult();

            if (_currentLevelGameObject != null)
            {
                DestroyLevel();
                DestroyHero();
            }

            CreateLevelHero();
            HideLoadingCurtain();
            Time.timeScale = 1;
        }

        private void ClearResult() =>
            _progressService.Progress.ClearCurrentLevelData();

        private async void CreateLevelHero()
        {
            _currentLevelGameObject = await _levelFactory.CreateLevel();
            Level.Level level = _currentLevelGameObject.GetComponent<Level.Level>();
            _heroGameObject = await level.CreateHero();
            _uiFactory.CreateAmuletCounter();
            _uiFactory.CreateControls(_heroGameObject);
        }

        private void SaveResult()
        {
            _progressService.Progress.UpLevel();
            _saveLoadService.SaveProgress();
        }

        private void DestroyLevel() =>
            _currentLevelGameObject.GetComponent<Level.Level>().Destroy();

        private void DestroyHero() =>
            _heroGameObject.GetComponent<HeroHealth>().Destroy();

        private void ShowLoadingCurtain() =>
            _curtain.Show();

        private void HideLoadingCurtain() =>
            _curtain.Hide();

        public void SetMedal()
        {
            Sprite medalSprite = _progressService.Progress.CurrentLevelData.CollectedMedalsCount < _progressService.Progress.CurrentLevelData.AllMedalsCount
                ? _silverMedalSprite
                : _goldMedalSprite;

            _progressService.Progress.SetMedalSprite(medalSprite);
        }
    }
}