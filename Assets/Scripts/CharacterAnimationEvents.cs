using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{

    public AudioClip aud_footStep;
    public AudioSource audio;
    void Start()
    {

    }
    public void FootStep()
    {
        audio.PlayOneShot(aud_footStep);
    }
}
