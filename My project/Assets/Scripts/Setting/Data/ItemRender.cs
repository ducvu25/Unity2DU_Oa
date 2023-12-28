using UnityEngine;
using System.Collections.Generic;

public static class ItemReader
{
    public static List<ItemSO> ReadItems()
    {
        List<ItemSO> itemList = new List<ItemSO>();

        // Tìm tất cả các file ItemSO trong thư mục Resources/Items
        ItemSO[] items = Resources.LoadAll<ItemSO>("Items");

        // Lưu danh sách các ItemSO vào itemList
        itemList.AddRange(items);

        return itemList;
    }
    public static ItemSO Search(List<ItemSO> a, string id)
    {
        int t = a.FindIndex(x => x.id == id);
        return t == -1 ? null : a[t];
    }
}