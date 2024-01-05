using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject goPlayer;
    [SerializeField] GameObject goGhost;
    [SerializeField] CameraFollow camera;

    [SerializeField] GameObject goSetting;

    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        goSetting.SetActive(false);
    }
    // Start is called before the first frame update
    public void Die(Vector3 p)
    {
        GameObject gameObject = Instantiate(goGhost, p, Quaternion.identity);
        camera.SetPlayer(gameObject);
        //Destroy(goPlayer);
    }
    public void Setting()
    {
        goSetting.SetActive(!goSetting.activeSelf);
    }
}
