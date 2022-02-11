using UnityEngine;

namespace Gameplay
{
    public class CustomCharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterController controller;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float speed = 10f;
        [SerializeField] private float jumpHeight = 1.5f;
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private float groundDistance = 0.4f;

        private Vector3 velocity;

        private bool isGrounded;

        public LayerMask GroundMask;

        private void Update()
        {
            Motion();
        }

        private void Motion()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, GroundMask);

            if (isGrounded && velocity.y < 0)
                velocity.y = -2f;

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * (speed * Time.deltaTime));

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
