using CodeBase.Services;
using CodeBase.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroCollector : MonoBehaviour
    {
        private IPersistentProgressService _progressService;

        private void Awake()
        {
            _progressService = AllServices.Container.Single<IPersistentProgressService>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Amulet"))
            {
                _progressService.Progress.IncreaseCollectedCount();
                Destroy(col.collider.gameObject);
            }
        }
    }
}