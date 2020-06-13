using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform Hinge;
    public float Speed = 1;

    private void Start()
    {
        GetComponent<Animator>().speed = Speed;
    }

    private void FixedUpdate()
    {
        if (Hinge) transform.position = Hinge.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}
