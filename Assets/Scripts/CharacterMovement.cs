using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{

    public Transform t_mesh;
    private Vector3 velocity;

    public float maxSpeed = 10f;

    private Rigidbody rigidbody;

    public Vector3 Velocity { get => velocity; set => velocity = value; }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // transform.Translate(velocity.normalized*maxSpeed);
        velocity = velocity.normalized * maxSpeed;
        rigidbody.velocity = new Vector3(velocity.x, rigidbody.velocity.y, velocity.z);
        Debug.Log(velocity * maxSpeed);
        if (velocity.magnitude > 0)
        {
            t_mesh.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
    }
}
