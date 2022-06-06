using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Transform t_mesh;
    private Vector3 velocity;

    public float maxSpeed = 0.1f;

    public Vector3 Velocity { get => velocity; set => velocity = value; }

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(velocity.normalized*maxSpeed);

        if (velocity.magnitude > 0)
        {
            t_mesh.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
    }
}
