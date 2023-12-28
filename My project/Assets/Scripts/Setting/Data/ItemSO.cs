using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemSO : ScriptableObject
{
    public string id;
    public Sprite sprite;
    public string name = "Ao";
    public ItemType type = ItemType.Skin;
    public int price = 0;
    public int typePrice = 0;
}

public enum ItemType
{
    Money,
    Skin,
    Other
}