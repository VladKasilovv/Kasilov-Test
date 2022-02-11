using UnityEngine;

namespace Gameplay
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 80f;
        private float _xRotation = 0f;

        public Transform PlayerBody;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            PlayerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
