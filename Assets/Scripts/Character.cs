using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    private float forwardInput;
    private float rightInput;

    private Vector3 velocity;

    public CameraController cameraController;
    public CharacterMovement characterMovement;
    public CharacterAnimationController characterAnimation;
    void Start()
    {

    }

    void Update()
    {
        // transform.Translate(velocity);
    }

    public void AddMovementInput(float forward, float right)
    {
        forwardInput = forward;
        rightInput = right;

        Vector3 camFwd = cameraController.transform.forward;
        Vector3 canRight = cameraController.transform.right;

        Vector3 translation = forward * cameraController.transform.forward;
        translation += right * cameraController.transform.right;

        if (translation.magnitude > 0)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }
        translation.y = 0;
        characterMovement.Velocity = translation;
    }
    public float getVelocity()
    {
        return characterMovement.Velocity.magnitude;
    }
    public void ToggleRun()
    {
        if (characterMovement.GetMovementMode() != MovementMode.Running)
        {
            characterMovement.SetMovementMode(MovementMode.Running);
            characterAnimation.SetMovementMode(MovementMode.Running);
        }
        else
        {
            characterMovement.SetMovementMode(MovementMode.Walking);
            characterAnimation.SetMovementMode(MovementMode.Walking);
        }
    }

    public void ToggleCrouch()
    {
        if (characterMovement.GetMovementMode() != MovementMode.Crouching)
        {
            characterMovement.SetMovementMode(MovementMode.Crouching);
            characterAnimation.SetMovementMode(MovementMode.Crouching);
        }
        else
        {
            characterMovement.SetMovementMode(MovementMode.Walking);
            characterAnimation.SetMovementMode(MovementMode.Walking);
        }
    }

    public void ToggleSprint(bool enable)
    {
        if (enable)
        {
            characterMovement.SetMovementMode(MovementMode.Sprinting);
            characterAnimation.SetMovementMode(MovementMode.Sprinting);
        }
        else
        {
            characterMovement.SetMovementMode(MovementMode.Running);
            characterAnimation.SetMovementMode(MovementMode.Running);
        }
    }
}
