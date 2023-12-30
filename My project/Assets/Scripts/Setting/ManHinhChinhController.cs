using System.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManHinhChinhController : MonoBehaviour
{
    [Header("-------Setting--------")]
    [SerializeField] GameObject selectSetting;
    [SerializeField] GameObject goSetting;
    [SerializeField] Sprite[] imgBackGround;

    [Header("-------Diem danh-------")]
    [SerializeField] GameObject goDiemDanh;

    [Header("--------Shop-------")]
    [SerializeField] GameObject goShop;

    [Header("-------Tin tuc--------")]
    [SerializeField] GameObject goTinTuc;

    [Header("-------TK cua bn--------")]
    [SerializeField] GameObject goTkCuaBn;

    [Header("-------Ds bb--------")]
    [SerializeField] GameObject goBB;

    [Header("-------Out player--------")]
    [SerializeField] GameObject goOutPlayer;

    [Header("-------Button---------")]
    [SerializeField] Sprite[] imgBtn;
    [SerializeField] GameObject goBtn;
    Color32[] clBtn = { new Color32(71, 2, 107, 255), new Color32(3, 83, 1, 255) };
    // Start is called before the first frame update
    void Start()
    {
        goSetting.SetActive(false);
        goDiemDanh.SetActive(false);
        goShop.SetActive(false);
        goTinTuc.SetActive(false);
        goTkCuaBn.SetActive(false);
        goBB.SetActive(false);
        goOutPlayer.SetActive(false);
    }
    public void TkCuaBan()
    {
        goTkCuaBn.SetActive(!goTkCuaBn.activeSelf);
    }
    public void Setting()
    {
        goSetting.SetActive(!goSetting.activeSelf);
    }
    public void BanBe()
    {
        goBB.SetActive(!goBB.activeSelf);
    }
    public void NgonNgu()
    {

    }
    public void OutPlayer()
    {
        goOutPlayer.SetActive(!goOutPlayer.activeSelf);
    }
    public void PhanThuongHangNgay()
    {
        goDiemDanh.SetActive(!goDiemDanh.activeSelf);
    }
    public void TinTuc()
    {
        goTinTuc.SetActive(!goTinTuc.activeSelf);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ChoiNhanh()
    {
        SceneManager.LoadScene(SettingController.nameMap[(int)IndexMap.play]);
    }
    public void BoSuuTap()
    {
        goShop.SetActive(!goShop.activeSelf);
    }
    public void HuongDan()
    {

    }
    public void TaoPhong()
    {

    }
    public void ChooseSetting(int value)
    {
        for(int i=0; i<goBtn.transform.childCount; i++)
        {
            goBtn.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = clBtn[0];
            goBtn.transform.GetChild(i).transform.GetComponent<Button>().image.sprite = imgBtn[0];
        }
        goBtn.transform.GetChild(value).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = clBtn[1];
        goBtn.transform.GetChild(value).transform.GetComponent<Button>().image.sprite = imgBtn[1];
        for (int i=1; i<selectSetting.transform.childCount; i++)
        {
            selectSetting.transform.GetChild(i).gameObject.SetActive(false);
        }
        selectSetting.transform.GetChild(value + 1).gameObject.SetActive(true);
        if(value == 2)
        {
            selectSetting.GetComponent<Image>().sprite = imgBackGround[1];
        }
        else
        {
            selectSetting.GetComponent<Image>().sprite = imgBackGround[0];
        }
    }
    public void ManHinhChinh()
    {
        SceneManager.LoadScene(SettingController.nameMap[(int)IndexMap.manHinhChinh]);
    }
}
