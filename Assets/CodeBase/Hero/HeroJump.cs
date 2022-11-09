using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 5f;

        private float _velocity;
        private GroundCheck _groundCheck;
        private float _gravity = -9.81f;
        private float _gravityScale = 5;
        private bool _jumped;

        private void Awake()
        {
            _groundCheck = GetComponent<GroundCheck>();
        }

        private void Update()
        {
            _velocity += _gravity * _gravityScale * Time.deltaTime;

            if (_groundCheck.isGrounded && _velocity <= 0)
            {
                _velocity = 0;

                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
                    Jump();
            }

            transform.Translate(new Vector2(0, _velocity) * Time.deltaTime);
        }

        private void Jump()
        {
            _velocity = _jumpForce;
        }
    }
}