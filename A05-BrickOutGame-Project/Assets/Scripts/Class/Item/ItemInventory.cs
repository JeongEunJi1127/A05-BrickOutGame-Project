using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    // ItemBall_Id : 1 ~ 1000
    // ItemPaddle_Id :1001 ~ 2000 
    private List<string> itemInventoryName = new List<string>();
    private List<int> itemInventoryId = new List<int>();
    private List<float> itemInventorySpeed = new List<float>();
    private List<float> itemInventorySize = new List<float>();
    private List<bool> itemInventoryisUseSpeed = new List<bool>();
    private List<bool> itemInventoryisUseSize = new List<bool>();

    // �Լ��� �տ� Get : Inventory List�� �߰�
    // �Լ��� �տ� Set : Inventory List���� �ش� index �� ������
    public void AddItemName(string name)
    {
        itemInventoryName.Add(name);
    }

    public void AddItemsId(int id)
    {
        itemInventoryId.Add(id);
    }

    public void AddItemsSpeed(float speed)
    {
        itemInventorySpeed.Add(speed);
    }

    public void AddItemsSize(float size)
    {
        itemInventorySize.Add(size);
    }
    public void AddUseSpeed(bool isUse)
    {
        itemInventoryisUseSpeed.Add(isUse);
    }
    public void AddUseSize(bool isUse)
    {
        itemInventoryisUseSize.Add(isUse);
    }

    public int ApplyItems()
    {
        return itemInventoryId.Count;
    }

    public string SetItemStatsName(int index)
    {
        return itemInventoryName[index];
    }

    public int SetItemStatsId(int index)
    {
        return itemInventoryId[index];
    }

    public float SetItemStatsSpeed(int index)
    {
        return itemInventorySpeed[index];
    }

    public float SetItemStatsSize(int index)
    {
        return itemInventorySize[index];
    }

    public bool SetUseSpeed(int index)
    {
        return itemInventoryisUseSpeed[index];
    }
    public bool SetUseSize(int index)
    {
        return itemInventoryisUseSize[index];
    }
}
