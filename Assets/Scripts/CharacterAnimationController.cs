using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterAnimationController : MonoBehaviour
{

    public Animator animator;
    private Character character;
    private float speed;

    void Start()
    {
        character = this.GetComponent<Character>();

        // Time.timeScale = .5f;
    }
    void Update()
    {
        if (animator == null)
        {
            // Debug.LogWarning("No valid Animator");
            return;
        }

        speed = Mathf.SmoothStep(speed, character.getVelocity(), Time.deltaTime * 20);

        animator.SetFloat("Velocity", speed);
        // Debug.Log(character.getVelocity()); 
    }

    public void SetMovementMode(MovementMode mode)
    {
        switch (mode)
        {
            case MovementMode.Walking:
                {
                    animator.SetInteger("Movement_State", 0);
                    break;
                }
            case MovementMode.Crouching:
                {
                    animator.SetInteger("Movement_State", 1);
                    break;
                }
            case MovementMode.Running:
                {
                    animator.SetInteger("Movement_State", 0);
                    break;
                }
            case MovementMode.Proning:
                {
                    animator.SetInteger("Movement_State", 2);
                    break;
                }
            case MovementMode.Swimming:
                {
                    animator.SetInteger("Movement_State", 3);
                    break;
                }
            case MovementMode.Sprinting:
                {
                    animator.SetInteger("Movement_State", 0);
                    break;
                }
        }
    }

}