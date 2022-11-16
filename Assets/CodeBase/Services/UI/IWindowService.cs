using CodeBase.StaticData.Windows;

namespace CodeBase.Services.UI
{
    public interface IWindowService : IService
    {
        public void CreateWindow(WindowId windowId);
    }
}