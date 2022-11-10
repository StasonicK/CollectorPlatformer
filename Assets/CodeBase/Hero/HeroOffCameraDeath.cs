using CodeBase.Services;
using CodeBase.StaticData.Windows;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroOffCameraDeath : MonoBehaviour
    {
        [SerializeField] private GameObject _levelLoaderGameObject;

        private void Update()
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            if (screenPosition.x > Screen.width || screenPosition.x < 0)
            {
                LevelLoader levelLoader = _levelLoaderGameObject.GetComponent<LevelLoader>();
                levelLoader.SetMedal();
                levelLoader.CreateWindow(WindowId.LevelRestart);
            }
        }
    }
}