using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float JumpSpeed = 5f;

    // Day 4 added ----------------------------------------------------------------------
    private bool jumping;
    public float JumpingSpeedFraction = 0.25f;

    private Rigidbody2D rb;
    private Animator anim;

    // Day 4 added ----------------------------------------------------------------------
    public GameObject Body;

    public GroundCheck GC;

    // Day 4 added ----------------------------------------------------------------------
    public float DeathForce = 500;
    private bool dead = false;
    public bool dying = false;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Day 4 added ----------------------------------------------------------------------
        if(!dying && !dead)
        {
            //old ------------------------------------------------------------------
            if (rb.velocity.x != 0) anim.SetBool("Walking", true);
            else anim.SetBool("Walking", false);

            if (GC.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jumping", true);
            }
        }
        // Day 4 added ----------------------------------------------------------------------
        else if (dying)
        {
            anim.SetTrigger("Dead");
        }
    }

    private void FixedUpdate()
    {
        // Day 4 added ----------------------------------------------------------------------
        if (!dying && !dead)
        {
            //old ------------------------------------------------------------------
            float h = Input.GetAxis("Horizontal");

            //calc force to add to player for WalkSpeed
            float F = ((WalkSpeed * h - rb.velocity.x) / Time.deltaTime) * rb.mass;  //((V - Vi)/time) * mass
            rb.AddForce(new Vector2(F, 0));

            if (h > 0) transform.localScale = new Vector3(1, 1, 1);
            else if (h < 0) transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }

    public void Jump()
    {
        if (GC.isGrounded)
        {
            float F = ((JumpSpeed - rb.velocity.y) / Time.deltaTime) * rb.mass;
            rb.AddForce(new Vector2(0, F));
        }
    }

    // Day 4 added ----------------------------------------------------------------------
    public void Die()
    {
        dying = false;
        dead = true;
        int childCount = Body.transform.childCount;
        Destroy(GetComponent<Animator>());
        for(int i = childCount - 1; i >= 0; i -= 1)
        {
            Transform child = Body.transform.GetChild(i);
            child.parent = null;
            child.gameObject.AddComponent<Rigidbody2D>();
            child.GetComponent<Collider2D>().enabled = true;

            Vector2 destructVector = (child.position - transform.position);
            child.GetComponent<Rigidbody2D>().AddForce(destructVector * DeathForce);
        }
        Body.transform.parent = null;
        Body.GetComponent<Collider2D>().enabled = true;
        Body.AddComponent<Rigidbody2D>();
        Destroy(gameObject);
    }
}
