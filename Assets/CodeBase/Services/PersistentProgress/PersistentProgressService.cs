using CodeBase.Progress;

namespace CodeBase.Services.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; private set; }

        public void SetPlayerProgress(PlayerProgress progress) =>
            Progress = progress;
    }
}