using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiemDanhController : MonoBehaviour
{
    [SerializeField] GameObject goBtnPre;
    [SerializeField] List<ButtonInformation> items;
    [SerializeField] Transform goPrarent;
    [SerializeField] Sprite imgTick;
    [SerializeField] Color32 color = new Color32(154, 143, 143, 255);
    [SerializeField] Sprite[] imgDays;

    [SerializeField] GameObject ruongBau;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<items.Count; i++)
        {
            GameObject goBtn = Instantiate(goBtnPre, goPrarent);
            int index = i;
            //goBtn.transform.parent = goPrarent;
            goBtn.transform.GetChild(0).GetComponent<Image>().sprite = items[i].item.sprite;
            goBtn.transform.GetChild(1).GetComponent<Image>().sprite = imgDays[i];
            if (!items[i].tick)
                goBtn.transform.GetChild(2).gameObject.SetActive(false);
            else
            {
                goBtn.transform.GetChild(2).gameObject.SetActive(true);
                goBtn.GetComponent<Button>().interactable = false;
                goBtn.GetComponent<Image>().color = color;
            }
            goBtn.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = items[i].item.type == ItemType.Money ? items[i].number.ToString() : items[i].item.name;
            goBtn.GetComponent<Button>().onClick.AddListener(() => {
                ruongBau.transform.GetChild(0).GetComponent<Image>().sprite = items[index].item.sprite;
                ruongBau.transform.GetComponent<Animator>().SetTrigger("Open");
                goBtn.transform.GetChild(2).gameObject.SetActive(true);
                goBtn.GetComponent<Button>().interactable = false;
                goBtn.GetComponent<Image>().color = color;
            });
        }
    }
}
[System.Serializable]
public class ButtonInformation
{
    public ItemSO item;
    public int number = 1;
    public bool tick = false;
}
