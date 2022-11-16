using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroHealth : MonoBehaviour
    {
        public void Destroy() =>
            Destroy(gameObject);
    }
}