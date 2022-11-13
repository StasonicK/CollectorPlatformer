using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _offset = 5f;
        [SerializeField] private float smoothTime = 0.5f;

        private Vector3 _moveVelocity;

        private void Update()
        {
            float getAxisHorizontal = Input.GetAxis("Horizontal");
            Vector3 targetPosition = new Vector2(transform.position.x + _offset * getAxisHorizontal, transform.position.y);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _moveVelocity, smoothTime, _speed);
        }
    }
}