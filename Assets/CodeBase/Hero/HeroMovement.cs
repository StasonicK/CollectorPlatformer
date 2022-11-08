using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;
        [SerializeField] private float _upForce = 5f;

        private Vector2 _moveVelocity;

        private void Update()
        {
            float getAxisHorizontal = Input.GetAxis("Horizontal");
            Vector2 moveVelocity = new Vector2(getAxisHorizontal, 0);
            _moveVelocity = moveVelocity.normalized * _speed;

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                Jump();
            }
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + _moveVelocity * Time.deltaTime);
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * _upForce, ForceMode2D.Force);
        }
    }
}