using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector4 duongBao;

    bool facingRight;
    Rigidbody2D rigidbody2D;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
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
        Debug.Log("ok");
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    void UpdateAnimation()
    {
        rigidbody2D.velocity = move * speed;
        if (transform.position.x <= duongBao.x)
        {
            transform.position = new Vector3(duongBao.x, transform.position.y, 0);
        }
        else if (transform.position.x >= duongBao.z)
        {
            transform.position = new Vector3(duongBao.z, transform.position.y, 0);
        }

        if (transform.position.y <= duongBao.y)
        {
            transform.position = new Vector3(transform.position.x, duongBao.y, 0);
        }
        else if (transform.position.y >= duongBao.w)
        {
            transform.position = new Vector3(transform.position.x, duongBao.w, 0);
        }
    }
}
