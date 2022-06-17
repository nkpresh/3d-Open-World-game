using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{

    public AudioClip aud_footStep;
    public AudioSource audio;
    public CharacterMovement characterMovement;
    void Start()
    {

    }
    public void FootStep(float targetWalkSpeed)
    {

        float actualSpeed = characterMovement.Velocity.magnitude;
        if (GetMovementState(targetWalkSpeed) == GetMovementState(actualSpeed))
        {
            audio.pitch = Mathf.Clamp((actualSpeed / 5), .6f, 1.3f);
            audio.volume = Mathf.Clamp(actualSpeed / 5, .3f, 1.5f);
            audio.PlayOneShot(aud_footStep);
        }
    }
    private int GetMovementState(float speed)
    {
        if (speed < .5f) return 0;
        if (speed < 3f) return 1;
        if (speed < 6f) return 2;
        return 3;
    }
}
