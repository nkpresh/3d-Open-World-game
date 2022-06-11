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
}