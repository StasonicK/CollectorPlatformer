using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _offset = 5f;
        [SerializeField] private float smoothTime = 0.5f;
        public Vector3 MoveVelocity;

        private void Update()
        {
            float getAxisHorizontal = Input.GetAxis("Horizontal");
            Debug.Log($"MoveVelocity: {MoveVelocity}");
            // Vector2 moveVelocity = new Vector2(getAxisHorizontal, 0);
            // MoveVelocity = moveVelocity.normalized * _speed;
            Vector3 targetPosition = new Vector2(transform.position.x + _offset * getAxisHorizontal, transform.position.y);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref MoveVelocity, smoothTime, _speed);
        }

        // private void FixedUpdate()
        // {
        //     _rigidbody2D.MovePosition(_rigidbody2D.position + MoveVelocity * Time.deltaTime);
        // }
    }
}