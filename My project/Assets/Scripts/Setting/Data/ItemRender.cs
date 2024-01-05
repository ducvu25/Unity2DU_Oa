using UnityEngine;
using System.Collections.Generic;

public static class ItemReader
{
    public static string sSkin = "Skins";
    public static string sIce = "Ices";
    public static string sHat = "Hats";
    public static string sDevice = "Devices";
    public static string sCard = "Cards";
    public static List<ItemSO> ReadItems(string s)
    {
        List<ItemSO> itemList = new List<ItemSO>();

        // Tìm tất cả các file ItemSO trong thư mục Resources/Items
        ItemSO[] items = Resources.LoadAll<ItemSO>("Items/" + s);

        // Lưu danh sách các ItemSO vào itemList
        itemList.AddRange(items);
        Debug.Log(s + " " + itemList.Count);
        return itemList;
    }
    public static ItemSO Search(List<ItemSO> a, string id)
    {
        int t = a.FindIndex(x => x.id == id);
        return t == -1 ? null : a[t];
    }
}