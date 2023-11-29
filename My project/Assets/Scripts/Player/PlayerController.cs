using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    bool facingRight = false;
    Rigidbody2D rigidbody2D;
    Animator animator;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInPut();
        UpdateAnimation();
    }
    void CheckInPut()
    {
        move = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            move.y = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            move.y = -1;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (facingRight)
                Flip();
            move.x = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!facingRight)
                Flip();
            move.x = 1;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void UpdateAnimation()
    {
        if(move != Vector2.zero)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        rigidbody2D.velocity = move*speed;

    }
}
