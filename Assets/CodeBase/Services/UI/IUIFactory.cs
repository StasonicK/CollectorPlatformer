using UnityEngine;

namespace CodeBase.Services.UI
{
    public interface IUIFactory : IService
    {
        void CreateAmuletCounter();
        Transform GetRootUI();
    }
}