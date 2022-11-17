using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private float _offset = 0.1f;

        public string jumpButton = "Jump";
        private float _velocity;
        private BoxCollider2D _boxCollider2D;
        private float _gravity = -9.81f;
        private float _gravityScale = 5;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            _velocity += _gravity * _gravityScale * Time.deltaTime;

            if (IsGrounded() && _velocity <= 0)
            {
                _velocity = 0;

                if (SimpleInput.GetButtonDown(jumpButton))
                    Jump();
            }

            transform.Translate(new Vector2(0, _velocity) * Time.deltaTime);
        }

        private bool IsGrounded()
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector3.down, _boxCollider2D.bounds.extents.y + _offset);
            return raycastHit2D != null;
        }

        private void Jump() =>
            _velocity = _jumpForce;
    }
}