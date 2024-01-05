using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [Header("-------Setting--------")]
    [SerializeField] GameObject selectSetting;
    [SerializeField] Sprite[] imgBackGround;

    [Header("-------Button---------")]
    [SerializeField] Sprite[] imgBtn;

    Color32[] clBtn = { new Color32(71, 2, 107, 255), new Color32(3, 83, 1, 255) };
    [SerializeField] GameObject goBtn;
    // Start is called before the first frame update
    public void ChooseSetting(int value)
    {
        for (int i = 0; i < goBtn.transform.childCount; i++)
        {
            goBtn.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = clBtn[0];
            goBtn.transform.GetChild(i).transform.GetComponent<Button>().image.sprite = imgBtn[0];
        }
        goBtn.transform.GetChild(value).transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = clBtn[1];
        goBtn.transform.GetChild(value).transform.GetComponent<Button>().image.sprite = imgBtn[1];
        for (int i = 1; i < selectSetting.transform.childCount; i++)
        {
            selectSetting.transform.GetChild(i).gameObject.SetActive(false);
        }
        selectSetting.transform.GetChild(value + 1).gameObject.SetActive(true);
        if (value == 2)
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
    public void Exit()
    {
        Application.Quit();
    }
}
