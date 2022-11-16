namespace CodeBase.Services.Levels
{
    public interface ILevelLoader : IService
    {
        void NextLevel();
        void RestartLevel();
        void SetMedal();
    }
}