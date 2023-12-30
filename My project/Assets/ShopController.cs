using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class ShopController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject goBtnPre;
    [SerializeField] Transform goParent;
    [SerializeField] Transform goParentBtnType;
    [SerializeField] Sprite[] imgTypePrices;
    int type = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Init", 1f);
    }
    void Init()
    {
        Database.LoadData();
        Show(Database.skins);
        for (int i = 0; i < goParentBtnType.childCount; i++)
        {
            int index = i;
            goParentBtnType.GetChild(i).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            goParentBtnType.GetChild(i).GetComponent<Button>().onClick.AddListener(() => {
                type = index;
                for (int j = 0; j < goParentBtnType.childCount; j++)
                {
                    goParentBtnType.GetChild(j).GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                goParentBtnType.GetChild(index).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                switch (type)
                {
                    case 0:
                        {
                            Show(Database.skins);
                            break;
                        }
                    case 1:
                        {
                            Show(Database.hats);
                            break;
                        }
                    case 2:
                        {
                            Show(Database.ices);
                            break;
                        }
                    case 3:
                        {
                            Show(Database.devices);
                            break;
                        }
                }
            });
        }
        goParentBtnType.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    void Show(List<ItemSO> items)
    {
        int childCount = goParent.transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject childObject = goParent.transform.GetChild(i).gameObject;
            DestroyImmediate(childObject);
        }
        for (int i = 0; i < items.Count; i++)
        {
            GameObject goBtn = Instantiate(goBtnPre, goParent);
            int index = i;
            goBtn.transform.GetChild(0).GetComponent<Image>().sprite = items[i].sprite;
            if (Database.Check(items[i]))
            {
                goBtn.transform.GetChild(1).gameObject.SetActive(false);
                goBtn.transform.GetChild(3).gameObject.SetActive(false);
                goBtn.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Đã sở hữu";
            }
            else
            {
                goBtn.transform.GetChild(1).GetComponent<Image>().sprite = imgTypePrices[items[i].typePrice];
                goBtn.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].price.ToString();
            }
            goBtn.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => {
                if (Database.Buy(items[index].price, items[index].typePrice))
                {
                    Database.Add(items[i]);
                    goBtn.transform.GetChild(1).gameObject.SetActive(false);
                    goBtn.transform.GetChild(3).gameObject.SetActive(false);
                    goBtn.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Đã sở hữu";
                }
            });
            goBtn.GetComponent<Button>().onClick.AddListener(() => {
                player.GetChild(type).GetComponent<Image>().sprite = items[index].sprite;
                if (Database.Check(items[index]))
                {
                    Database.Used(items[i], type);
                }
            });
        }
    }
}
