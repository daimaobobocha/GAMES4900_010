using UnityEngine;

namespace AOTADev
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private float acceleration = 30f;
        [SerializeField] private float braking = 40f;

        [Header("Jump")]
        [SerializeField] private float jumpForce = 6f;
        [SerializeField] private float groundCheckDistance = 1.1f;
        [SerializeField] private LayerMask groundMask = ~0;

        private Rigidbody _rb;
        private float _horizontalInput;
        private bool _jumpPressed;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // A = -1, D = 1
            _horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
                _jumpPressed = true;
        }

        private void FixedUpdate()
        {
            MoveLeftRight();
            TryJump();
        }

        private void MoveLeftRight()
        {
            // 只沿着角色自己的左右方向移动
            Vector3 right = transform.right;
            Vector3 currentVelocity = _rb.linearVelocity;
            Vector3 horizontalVelocity = Vector3.Project(currentVelocity, right);

            Vector3 targetVelocity = right * (_horizontalInput * moveSpeed);
            Vector3 velocityDiff = targetVelocity - horizontalVelocity;

            float accel = Mathf.Abs(_horizontalInput) > 0.01f ? acceleration : braking;
            Vector3 force = Vector3.ClampMagnitude(velocityDiff * accel, accel);

            _rb.AddForce(force, ForceMode.Acceleration);
        }

        private void TryJump()
        {
            if (!_jumpPressed)
                return;

            _jumpPressed = false;

            if (!IsGrounded())
                return;

            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(
                transform.position,
                Vector3.down,
                groundCheckDistance,
                groundMask,
                QueryTriggerInteraction.Ignore
            );
        }
    }
}