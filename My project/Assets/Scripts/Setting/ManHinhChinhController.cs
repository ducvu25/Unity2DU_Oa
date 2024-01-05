using System.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManHinhChinhController : MonoBehaviour
{
    [Header("-------Setting--------")]
    [SerializeField] GameObject goSetting;

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
        SceneManager.LoadScene(SettingController.nameMap[(int)IndexMap.huongDan]);
    }
    public void TaoPhong()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
}
