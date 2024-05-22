using System.Collections;
using UnityEngine;

public class ItemApplyManager : MonoBehaviour
{
    public ItemBallApply ballApply;
    private Transform ballTransform;

    private float ApplyItemTime = 5f;
    private float itemSpeed;
    private float itemSize;
    
    private float ballInitSpeed;
    private float ballInitSizex;
    private float ballInitSizey;

    private bool isUseItemSize = false;

    private void Awake()
    {
        ballApply = ballApply.GetComponent<ItemBallApply>();
        ballTransform = ballApply.GetComponent <Transform>();
    }

    // �浹�� Item Speed �� Ball�� �����ϱ�
    public float ApplyBallItemSpeed(float speed)
    {
        ballInitSpeed = speed;

        itemSpeed = ballApply.SetItemSpeed();

        StartCoroutine("isUsedItemSpeed", ApplyItemTime);

        return ballInitSpeed * itemSpeed;
    }

    // �浹�� Item Size �� Ball�� �����ϱ�
    public void ApplyBallItemSize()
    {
        Transform size = ballTransform;

        ballInitSizex = size.localScale.x;
        ballInitSizey = size.localScale.y;

        itemSize = ballApply.SetItemSize();

        size.localScale = new Vector2(ballInitSizex * itemSize, ballInitSizey * itemSize);

        StartCoroutine("isUsedItemSize", ApplyItemTime);
    }

    // �ڷ�ƾ : Ball Speed ���� Item ���� �ð�
    IEnumerator isUsedItemSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        ballApply.GetUseItemSpeed(false, ballInitSpeed);
    }
    // �ڷ�ƾ : Ball Size ���� Item ���� �ð�
    IEnumerator isUsedItemSize(float time)
    {
        yield return new WaitForSeconds(time);
        Transform size = ballTransform;

        size.localScale = new Vector2(ballInitSizex, ballInitSizey);

        ballApply.GetIsUseItemSize(isUseItemSize);
    }
}
