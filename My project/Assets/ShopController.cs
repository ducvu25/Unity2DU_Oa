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
    [Header("\n------Chuc nang loai 2_1------")]
    [SerializeField] GameObject goBtnPre;
    [SerializeField] Transform goParent;
    [SerializeField] Transform goParentBtnType;
    [SerializeField] Sprite[] imgTypePrices;
    int type = 0;

    [Header("\n------Chuc nang loai 2_2------")]
    [SerializeField] GameObject goBtnPre2;
    [SerializeField] Transform goParent2;
    [SerializeField] Transform player2;

    [Header("\n------Chuc nang loai 1------")]
    [SerializeField] GameObject[] goButtonChucNangs;

    [Header("\n------Txt coin------")]
    [SerializeField] TextMeshProUGUI[] txtCoins;


    // Start is called before the first frame update
    void Start()
    {
        Database.LoadData();
        txtCoins[0].text = Database.coins[0].ToString();
        txtCoins[1].text = Database.coins[1].ToString();
        Invoke("Choice", 0.5f);
    }
    void Choice()
    {
        Choice(0);
    }
    public void Choice(int value)
    {
        for(int i=0; i<goButtonChucNangs.Length; i++)
        {
            goButtonChucNangs[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        goButtonChucNangs[value].transform.GetChild(0).gameObject.SetActive(true);
        switch (value)
        {
            case 0:
                {
                    Init();
                    break;
                }
            case 1:
                {
                    Show2(Database.cards);
                    break;
                }
            case 2:
                {
                    Init();
                    break;
                }
        }
    }
    void Init()
    {
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
    void Show2(List<ItemSO> items)
    {
        int childCount = goParent2.transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject childObject = goParent2.transform.GetChild(i).gameObject;
            DestroyImmediate(childObject);
        }
        for (int i = 0; i < items.Count; i++)
        {
            GameObject goBtn = Instantiate(goBtnPre2, goParent2);
            int index = i;
            goBtn.transform.GetComponent<Image>().sprite = items[i].sprite;
            goBtn.GetComponent<Button>().onClick.AddListener(() => {
                player2.GetChild(0).GetComponent<Image>().sprite = items[index].sprite;    
            });
        }
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
                    txtCoins[items[index].typePrice].text = Database.coins[items[index].typePrice].ToString();
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
