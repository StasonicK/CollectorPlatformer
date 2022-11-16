using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;

namespace CodeBase.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        LevelStaticData ForLevel(LevelId levelId);
        WindowStaticData ForWindow(WindowId windowId);
    }
}