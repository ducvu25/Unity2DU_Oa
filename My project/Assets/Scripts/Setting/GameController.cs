using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject goPlayer;
    [SerializeField] GameObject goGhost;
    [SerializeField] CameraFollow camera;

    [SerializeField] GameObject goSetting;
    [SerializeField] GameObject goNhiemVu;
    List<bool> thucHienNV;
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        goSetting.SetActive(false);

        thucHienNV = new List<bool>();
        for(int i=0; i< goNhiemVu.transform.childCount; i++)
        {
            goNhiemVu.transform.GetChild(i).gameObject.SetActive(false);
            thucHienNV.Add(false);
        }
        goNhiemVu.SetActive(false);
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
    public void NhiemVu(int type)
    {
        goNhiemVu.SetActive(true);
        for (int i = 0; i < goNhiemVu.transform.childCount; i++)
        {
            goNhiemVu.transform.GetChild(i).gameObject.SetActive(false);
        }
        goNhiemVu.transform.GetChild(type).gameObject.SetActive(true);
        switch (type)
        {
            case 0:
                {
                    NhiemVuLapTop();
                    break;
                }
        }
    }
    void NhiemVuLapTop()
    {
        goNhiemVu.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
        goNhiemVu.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
        goNhiemVu.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(thucHienNV[0] ? 1 : 2).gameObject.SetActive(true);
    }
    public void ThucHienNhiemVu(int type)
    {
        thucHienNV[type] = true;
        switch (type)
        {
            case 0:
                {
                    goNhiemVu.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
                    goNhiemVu.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
                    break;
                }
        }
    }
    public void closeNhiemVu()
    {
        goNhiemVu.SetActive(false);
    }
}
