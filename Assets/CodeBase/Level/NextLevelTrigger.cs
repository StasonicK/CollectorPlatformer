using CodeBase.Hero;
using CodeBase.Services;
using CodeBase.StaticData.Windows;
using UnityEngine;

namespace CodeBase.Level
{
    public class NextLevelTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _levelLoaderGameObject;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<HeroMovement>(out HeroMovement hero))
            {
                LevelLoader levelLoader = _levelLoaderGameObject.GetComponent<LevelLoader>();
                levelLoader.SetMedal();
                levelLoader.CreateWindow(WindowId.LevelFinished);
            }
        }
    }
}