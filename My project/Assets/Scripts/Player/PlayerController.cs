using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool type = true;
    bool facingRight = false;
    Rigidbody2D rigidbody2D;
    Animator animator;
    Vector2 move;
    bool die;
    [SerializeField] GameObject goPlayer2 = null;
    [SerializeField] float distance = 10;
    bool checkCauThang = false;
    // Start is called before the first frame update
    void Start()
    {
        die = false;
        rigidbody2D = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            return; 
        }
        CheckInPut();
        UpdateAnimation();
    }
    void CheckInPut()
    {
        move = Vector2.zero;
        if ((Input.GetKey(KeyCode.UpArrow) && type) || (Input.GetKey(KeyCode.W) && !type))
            move.y = 1;
        if ((Input.GetKey(KeyCode.DownArrow) && type) || (Input.GetKey(KeyCode.S) && !type))
            move.y = -1;
        if ((Input.GetKey(KeyCode.LeftArrow) && type) || (Input.GetKey(KeyCode.A) && !type))
        {
            if (facingRight)
                Flip();
            move.x = -1;
            if (checkCauThang)
                move.y = 0.2f;
        }
        if ((Input.GetKey(KeyCode.RightArrow) && type) || (!type && Input.GetKey(KeyCode.D)))
        {
            if (!facingRight)
                Flip();
            move.x = 1;
            if (checkCauThang)
                move.y = -0.2f;
        }
        if(Input.GetKey(KeyCode.R) && type && goPlayer2 != null && Vector2.Distance(transform.position, goPlayer2.transform.position) < distance) {
            die = true;
            animator.SetTrigger("Die");
            Invoke("InstacteGhost", 1f);
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
            animator.SetBool("Type", type);
            animator.SetBool("Run", true);
            AudioController.instance.Play(type ? (int)EffectAudio.run1 : (int)EffectAudio.run2);
        }
        else
        {
            AudioController.instance.Stop(type ? (int)EffectAudio.run1 : (int)EffectAudio.run2);
            animator.SetBool("Run", false);
        }
        rigidbody2D.velocity = move*speed;

    }
    void InstacteGhost()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        GameController.instance.Die(transform.position);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CauThang"))
        {
            print("ok");
            checkCauThang = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CauThang"))
        {
            print("no");
            checkCauThang = false;
        }
    }
}
