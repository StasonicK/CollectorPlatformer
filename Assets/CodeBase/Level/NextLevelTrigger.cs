using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Level
{
    public class NextLevelTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<HeroMovement>(out HeroMovement hero))
            {
                
            }
        }
    }
}