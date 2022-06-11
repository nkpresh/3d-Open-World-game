using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]

public class PlayerInput : MonoBehaviour
{
    private Character character;
    private CharacterMovement characterMovement;
    void Start()
    {
        character = GetComponent<Character>();
    }

    void Update()
    {
        character.AddMovementInput(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            character.ToggleRun();

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            character.ToggleCrouch();

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            character.ToggleSprint(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            character.ToggleSprint(false);
        }
    }
}
