using UnityEngine;

namespace CodeBase.Services.Levels
{
    public interface ILevelFactory : IService
    {
        public GameObject CreateLevel();
    }
}