using CodeBase.Services;
using CodeBase.Services.UI;
using CodeBase.StaticData.Windows;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroOffCameraDeath : MonoBehaviour
    {
        private IWindowService _windowService;
        private bool _windowCreated = false;

        private void Start()
        {
            _windowService = AllServices.Container.Single<IWindowService>();
        }

        private void Update()
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            if (_windowCreated == false)
            {
                if (screenPosition.x > Screen.width || screenPosition.x < 0 || screenPosition.y < 0)
                {
                    Time.timeScale = 0;
                    _windowService.CreateWindow(WindowId.LevelRestart);
                    _windowCreated = true;
                }
            }
        }
    }
}