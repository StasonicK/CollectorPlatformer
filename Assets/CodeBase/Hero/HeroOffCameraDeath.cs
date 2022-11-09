using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class HeroOffCameraDeath : MonoBehaviour
    {
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void LateUpdate()
        {
            if (!_renderer.isVisible)
                ;
        }
    }
}