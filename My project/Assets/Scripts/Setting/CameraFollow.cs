using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector4 duongBao;
    GameObject player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position; // => position new = offset + player
    }

    // Update is called once per frame
    void Update()
    {
        Vector3  move = player.transform.position + offset;
        transform.position = Vector2.MoveTowards(transform.position, move, speed * Time.deltaTime); // cap nhat vi tri moi
        if (transform.position.x <= duongBao.x)
        {
            transform.position = new Vector3(duongBao.x, transform.position.y, -10);
        }else if(transform.position.x >= duongBao.z)
        {
            transform.position = new Vector3(duongBao.z, transform.position.y, -10);
        }

        if (transform.position.y <= duongBao.y)
        {
            transform.position = new Vector3(transform.position.x, duongBao.y, -10);
        }
        else if (transform.position.y >= duongBao.w)
        {
            transform.position = new Vector3(transform.position.x, duongBao.w, -10);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
    public void SetPlayer(GameObject gameObject)
    {
        player = gameObject;
    }
    public void SetSpeed(float t)
    {
        speed = t;
    }
}
