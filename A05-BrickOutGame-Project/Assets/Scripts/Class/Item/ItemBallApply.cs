using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemBallApply : MonoBehaviour
{
    public ItemApplyManager applyManager;
    private Item item;
    private BallMovement ballMovement;

    private int itemId = 0;

    private void Awake()
    {
        ballMovement = GetComponent<BallMovement>();
        applyManager = applyManager.GetComponent<ItemApplyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            item = collision.GetComponent<Item>();
            collision.gameObject.SetActive(false);
            itemId = item.Id;
        }

        if (itemId >= 1 && itemId <= 1000)
        {
            if (itemId == 1 || itemId == 2)
                applyManager.ApplyBallItemSize();
            else if (itemId == 3 || itemId == 4)
            {
                // ���� ball Speed�� �޾ƿͼ�, ������ Speed�� ������ ��, �װ� �ٽ� ballMovment�� ����
                ballMovement.GetBallSpeed(applyManager.ApplyBallItemSpeed(ballMovement.SetBallSpeed()));
            }
        }
        else if (itemId >= 1001 && itemId <= 2000)
        {
            if (itemId == 1001 || itemId == 1002)
                applyManager.ApplyPaddleItemSize();
            else if (itemId == 1003 || itemId == 1004)
                applyManager.ApplyPaddleItemSpeed();
        }
    }

    public float SetItemSpeed()
    {
        return item.Speed;
    }

    public float SetItemSize()
    {
        return item.Size;
    }
}
