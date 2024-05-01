using UnityEngine;
using UnityEngine.UI;


namespace UnityStandardAssets.Characters.FirstPerson
{
    public class FirstPersonControllerCustom : MonoBehaviour
    {
        public float walkingSpeed = 9f;
        public float runningSpeed = 112.5f;
        public float jumpSpeed = 8f;
        public float gravity = 20f;
        public Camera playerCamera;
        public float lookSpeed = 100f;
        public float lookXLimit = 45f;


        private CharacterController characterController;
        private Vector3 moveDirection = Vector3.zero;
        private float rotationX;

        [HideInInspector]
        public bool canMove = true;

        [HideInInspector]
        public StaminaController _staminaController;

        public AudioClip walkingSound;
        private AudioSource audioSource;

        public bool CanMove
        {
            get { return canMove; }
            set { canMove = value; }
        }

        public Slider SensitivitySlider;

        private const string SensitivityKey = "Sensitivity";

        private void Start()
        {
            _staminaController = GetComponent<StaminaController>();
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


            
            lookSpeed = PlayerPrefs.GetFloat(SensitivityKey, 4f);

            
            SensitivitySlider.value = lookSpeed;
        }

        public void AdjustSpeed(float newSpeed)
        {
            lookSpeed = newSpeed * 1;

            
            PlayerPrefs.SetFloat(SensitivityKey, newSpeed);
        }

        public void SetRunSpeed(float speed)
        {
            runningSpeed = speed;
        }



        private void Update()
        {
            Vector3 vector = transform.TransformDirection(Vector3.forward);
            Vector3 vector2 = transform.TransformDirection(Vector3.right);
            bool key = Input.GetKey(KeyCode.LeftShift);

            if (!key)
            {
                _staminaController.weAreSprinting = false;
            }

            if (key && _staminaController.playerStamina > 0f)
            {
                _staminaController.weAreSprinting = true;
                _staminaController.Sprinting();
            }

            float num = (canMove ? ((key ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical")) : 0f);
            float num2 = (canMove ? ((key ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal")) : 0f);
            float y = moveDirection.y;

            moveDirection = vector * num + vector2 * num2;


            

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = y;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += (-Input.GetAxis("Mouse Y")) * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
                transform.rotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * lookSpeed, 0f);
            }


        }
    }
}
