using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterAnimationController : MonoBehaviour
{

    public Animator animator;
    private Character character;

    void Start()
    {
        character = this.GetComponent<Character>();
    }
    void Update()
    {
        if (animator == null)
        {
            Debug.LogWarning("No valid Animator");
            return;
        }
        
        animator.SetFloat("Velocity", character.getVelocity());
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
                    animator.SetInteger("Movement_State", 4);
                    break;
                }
        }
    }

}