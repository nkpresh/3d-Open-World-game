using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementMode
{
    Walking,
    Running,
    Crouching,
    Proning,
    Swimming,
    Sprinting
}
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public Transform t_mesh;
    private Vector3 velocity;
    public float maxSpeed = 10f;

    public float walkSpeed = 3.33f;
    public float runSpeed = 6.7f;
    public float sprintSpeed = 10f;
    public float crouchSpeed = 3.33f;
    public float proningSpeed = 1f;
    public float swimSpeed = 3.33f;




    private float smoothSpeed;
    private float smoothRotation = 10;

    private Rigidbody rigidbody;
    private MovementMode movementMode;
    public Vector3 Velocity { get => rigidbody.velocity; set => velocity = value; }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        SetMovementMode(MovementMode.Walking);
    }

    void Update()
    {
        
        // Debug.Log(velocity * maxSpeed);
        if (velocity.magnitude > 0)
        {
            rigidbody.velocity = new Vector3(velocity.normalized.x * smoothSpeed, rigidbody.velocity.y, velocity.normalized.z * smoothSpeed);
            smoothSpeed = Mathf.Lerp(smoothSpeed, maxSpeed, Time.deltaTime);
            // t_mesh.rotation = Quaternion.LookRotation(velocity, Vector3.up);
            t_mesh.rotation = Quaternion.Lerp(t_mesh.rotation, Quaternion.LookRotation(velocity, Vector3.up), Time.deltaTime*smoothRotation);

        }
        else
        {
            smoothSpeed = Mathf.Lerp(smoothSpeed, 0, Time.deltaTime * 4);

        }
    }

    public void SetMovementMode(MovementMode mode)
    {
        movementMode = mode;
        switch (mode)
        {
            case MovementMode.Walking:
                {
                    maxSpeed = walkSpeed;
                    break;
                }
            case MovementMode.Crouching:
                {
                    maxSpeed = crouchSpeed;
                    break;
                }
            case MovementMode.Running:
                {
                    maxSpeed = runSpeed;
                    break;
                }
            case MovementMode.Proning:
                {
                    maxSpeed = proningSpeed;
                    break;
                }
            case MovementMode.Swimming:
                {
                    maxSpeed = swimSpeed;
                    break;
                }
            case MovementMode.Sprinting:
                {
                    maxSpeed = sprintSpeed;
                    break;
                }
        }
    }

    public MovementMode GetMovementMode()
    {
        return movementMode;
    }
}
