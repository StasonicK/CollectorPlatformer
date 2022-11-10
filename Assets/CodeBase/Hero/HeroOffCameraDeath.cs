using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroOffCameraDeath : MonoBehaviour
    {
        private HeroDeath _heroDeath;

        private void Awake()
        {
            _heroDeath = GetComponent<HeroDeath>();
        }

        private void Update()
        {
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            if (screenPosition.x > Screen.width || screenPosition.x < 0)
                _heroDeath.Died?.Invoke();
        }
    }
}