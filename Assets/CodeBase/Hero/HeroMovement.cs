using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _offset = 5f;
        [SerializeField] private float smoothTime = 0.5f;

        public string horizontalAxis = "Horizontal";
        private float inputHorizontal;
        private Coroutine _moveCoroutine;
        private Vector3 _moveVelocity;
        private const float ToLeftValue = -1f;
        private const float ToRightValue = 1f;

        private void Update()
        {
            inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
            Vector3 targetPosition = new Vector2(transform.position.x + _offset * inputHorizontal, transform.position.y);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _moveVelocity, smoothTime, _speed);
        }
    }
}