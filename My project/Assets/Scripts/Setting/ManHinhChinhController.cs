using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManHinhChinhController : MonoBehaviour
{
    [Header("-------Setting--------")]
    [SerializeField] GameObject selectSetting;
    [SerializeField] GameObject goSetting;
    [SerializeField] Sprite[] imgBackGround;
    // Start is called before the first frame update
    void Start()
    {
        goSetting.SetActive(false);
    }

    // Update is called once per frame
   /* void Update()
    {
        
    }*/
    public void DsBB()
    {

    }
    public void Setting()
    {
        goSetting.SetActive(!goSetting.activeSelf);
    }
    public void ThayDo()
    {

    }
    public void NgonNgu()
    {

    }
    public void PhanThuongHangNgay()
    {

    }
    public void TinTuc()
    {

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

    }
    public void HuongDan()
    {

    }
    public void TaoPhong()
    {

    }
    public void ChooseSetting(int value)
    {
        for(int i=1; i<selectSetting.transform.childCount; i++)
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
}
