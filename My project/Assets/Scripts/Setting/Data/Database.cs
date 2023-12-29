
using System.Collections.Generic;

public static class Database
{
    public static List<ItemSO> skins;
    public static List<ItemSO> hats;
    public static List<ItemSO> ices;
    public static List<ItemSO> devices;
    public static List<ItemSO> users;
    public static ItemSO[] player = {null, null, null}; 
    public static int[] coins = { 0, 0 };
    public static void LoadData()
    {
        skins = ItemReader.ReadItems(ItemReader.sSkin);
        hats = ItemReader.ReadItems(ItemReader.sHat);
        ices = ItemReader.ReadItems(ItemReader.sIce);
        devices = ItemReader.ReadItems(ItemReader.sDevice);
        users = new List<ItemSO>();
        coins[0] = 1000;
        coins[1] = 1000;
    }
    public static void Add(ItemSO item, int number = 1)
    {
        if(item.type == ItemType.Money)
        {
            coins[item.typePrice] += number;
        }else if (!users.Contains(item))
        {
            users.Add(item);
        }
    }
    public static bool Buy(int number, int type)
    {
        if (coins[type] >= number) {
            coins[type] -= number;
            return true;
        }
        return false;
    }
    public static bool Check(ItemSO item)
    {
        return users.Contains(item);
    }
    public static void Used(ItemSO item, int type)
    {
        player[type] = item;
    }
}
