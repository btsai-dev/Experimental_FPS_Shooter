using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    [SerializeField]
    private float _lookSensitivity = 3f;


    private PlayerMotor _motor;
    void Start()
    {
        _motor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        // Calculate movement velocity as a 3D vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov; // (1,0,0)
        Vector3 movVertical = transform.forward * zMov; // (0,0,1)

        // Final movement vector
        Vector3 velocity = (movHorizontal + movVertical).normalized * _speed; // Normalize makes vector length one

        // Apply movement
        _motor.Move(velocity);

        // Calculate rotation as a 3D vector for turning
        float yRot = Input.GetAxisRaw("Mouse X"); // When we move mouse left and right (X axis on 2d and Y axis on 3d)

        Vector3 rotation = new Vector3(0f, yRot, 0f) * _lookSensitivity;

        // Apply rotation
        _motor.Rotate(rotation);

        // Calculate camera rotation as a 3D vector for looking vertical
        float xRot = Input.GetAxisRaw("Mouse Y"); // When we move mouse left and right (X axis on 2d and Y axis on 3d)

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * _lookSensitivity;

        // Apply rotation
        _motor.CameraRotation(cameraRotation);

    }

}
