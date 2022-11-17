using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Services.Levels
{
    public interface ILevelFactory : IService
    {
        public Task<GameObject> CreateLevel();
    }
}