using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroCollecter : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("Amulet"))
            {
                Destroy(col.collider.gameObject);
            }
        }
    }
}