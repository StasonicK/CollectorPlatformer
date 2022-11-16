using CodeBase.Progress;
using CodeBase.Services;
using CodeBase.Services.Input;
using CodeBase.Services.Levels;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.SaveLoad;
using CodeBase.Services.StaticData;
using CodeBase.Services.UI;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private Sprite _goldMedalSprite;
        [SerializeField] private Sprite _silverMedalSprite;
        [SerializeField] private LoadingCurtain _curtain;
        [SerializeField] private GameObject _mobileInputGameObject;
        [SerializeField] private GameObject _rootUIGameObject;

        private AllServices _allServices = new AllServices();

        private void Awake()
        {
            RegisterServices();
            LoadResources();
            LoadLevel();
            CreateInput();
            DontDestroyOnLoad(this);
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _allServices.RegisterSingle<ISaveLoadService>(new SaveLoadService(_allServices.Single<IPersistentProgressService>()));
            _allServices.RegisterSingle<IStaticDataService>(new StaticDataService());
            _allServices.RegisterSingle<ILevelFactory>(new LevelFactory(_allServices.Single<IStaticDataService>(),
                _allServices.Single<IPersistentProgressService>()
            ));
            _allServices.RegisterSingle<IUIFactory>(new UIFactory(_allServices.Single<IPersistentProgressService>(), _allServices.Single<IStaticDataService>(),
                _rootUIGameObject.transform));
            _allServices.RegisterSingle<ILevelLoader>(new LevelLoader(_silverMedalSprite, _goldMedalSprite, Instantiate(_curtain),
                _allServices.Single<ILevelFactory>(), _allServices.Single<IPersistentProgressService>(), _allServices.Single<ISaveLoadService>(),
                _allServices.Single<IUIFactory>()));
            _allServices.RegisterSingle<IWindowService>(new WindowService(_allServices.Single<IStaticDataService>(), _allServices.Single<IUIFactory>(),
                _allServices.Single<IPersistentProgressService>()));
        }

        private void LoadResources()
        {
            _allServices.Single<IStaticDataService>().Load();
            _allServices.Single<IPersistentProgressService>().SetPlayerProgress(_allServices.Single<ISaveLoadService>().LoadProgress() ?? NewPlayerProgress());
        }

        private static PlayerProgress NewPlayerProgress()
        {
            PlayerProgress progress = new PlayerProgress();
            progress.Initialize();
            return progress;
        }

        private void LoadLevel()
        {
            _allServices.Single<ILevelLoader>().RestartLevel();
        }

        private void CreateInput()
        {
            MobileInput mobileInput = _mobileInputGameObject.GetComponent<MobileInput>();
        }
    }
}