using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawArm : MonoBehaviour
{
    public float Speed = 1;

    public enum SawModes
    {
        Idle,
        Rotation,
        Reciprocation
    }
    public SawModes SawMode;

    private void Start()
    {
        GetComponent<Animator>().speed = Speed;
        if (SawMode == SawModes.Reciprocation) GetComponent<Animator>().SetTrigger("Reciprocation");
        else if(SawMode == SawModes.Rotation) GetComponent<Animator>().SetTrigger("Rotation");
    }

    
}
