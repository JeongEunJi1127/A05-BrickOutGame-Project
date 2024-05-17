using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] itemImages;
    private System.Random random;
    private ItemInventory inventory;
    public Item items;

    private int itemIndex;

    private void Awake()
    {
        random = new System.Random();
        inventory = GetComponent<ItemInventory>();
    }
    private void Start()
    {
        itemIndex = random.Next(0, inventory.ApplyItems());
        items.GetComponent<SpriteRenderer>().sprite = itemImages[itemIndex].sprite;

        // ������ ���� ���� - ���� ����, ���� �ð� ���Ŀ� ����
        Instantiate(items).CreateItem(
            inventory.GetItemStatsName(itemIndex), inventory.GetItemStatsId(itemIndex), inventory.GetItemStatsSpeed(itemIndex),
            inventory.GetItemStatsSize(itemIndex));
    }

    public int GetIndexNum()
    {
        return itemIndex;
    }

}
