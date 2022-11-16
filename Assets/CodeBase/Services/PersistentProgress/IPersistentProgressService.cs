using CodeBase.Progress;

namespace CodeBase.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        public PlayerProgress Progress { get; }

        void SetPlayerProgress(PlayerProgress progress);
    }
}