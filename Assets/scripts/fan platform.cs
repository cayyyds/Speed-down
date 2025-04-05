using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanplatform : MonoBehaviour
{
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("fan_move");
        }
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 2f);


    }
}
