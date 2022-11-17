using UnityEngine;

namespace CodeBase.Services.Levels
{
    public interface ILevelLoader : IService
    {
        GameObject GetHeroGameObject();
        void NextLevel();
        void RestartLevel();
        void SetMedal();
    }
}