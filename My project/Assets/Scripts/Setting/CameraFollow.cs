using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float speed;
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
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
