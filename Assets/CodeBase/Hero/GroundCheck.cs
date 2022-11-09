using UnityEngine;

namespace CodeBase.Hero
{
    public class GroundCheck : MonoBehaviour
    {
        public bool isGrounded = true;

        public float _offset = 2f;
        private Collider2D[] _results = new Collider2D[1];
        private ContactFilter2D _filter;

        private void Update()
        {
            Vector2 point = transform.position + Vector3.down * _offset;
            Vector2 size = new Vector2(0.75f, 0.75f);

            if (Physics2D.OverlapBox(point, size, 0, _filter.NoFilter(), _results) > 0)
            {
                Vector2 surfacePosition = Physics2D.ClosestPoint(transform.position, _results[0]);
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
    }
}