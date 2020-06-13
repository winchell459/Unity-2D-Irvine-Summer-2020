using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawArm : MonoBehaviour
{
    public float Speed = 1;
    public SawModes SawMode;

    public Transform Saw;
    public Transform Hinge;

    public enum SawModes
    {
        Idle,
        Rotation,
        Reciprocation
    }

    private void Start()
    {
        Animator anim = GetComponent<Animator>();
        anim.speed = Speed;
        if (SawMode == SawModes.Reciprocation) anim.SetTrigger("Reciprocation");
        else if (SawMode == SawModes.Rotation) anim.SetTrigger("Rotation");
    }

    private void FixedUpdate()
    {
        if (Saw) Saw.position = Hinge.position;
    }
}
