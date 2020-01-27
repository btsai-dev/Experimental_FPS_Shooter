using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 _velocity = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;
    private Vector3 _cameraRotation = Vector3.zero;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Runs every physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation(); 
    }

    public void Move (Vector3 velocity)
    {
        _velocity = velocity;
    }

    // Gets a rotation vector
    public void Rotate(Vector3 rotation)
    {
        _rotation = rotation;
    }

    // Gets a rotation vector for camera
    public void CameraRotation(Vector3 cameraRotation)
    {
        _cameraRotation = cameraRotation;
    }

    // Move based on velocity
    void PerformMovement()
    {
        if (_velocity != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime );
        }
    }

    void PerformRotation()
    {
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(_rotation));
        if (cam != null)
        {
            cam.transform.Rotate(- _cameraRotation);
        }
    }

}
