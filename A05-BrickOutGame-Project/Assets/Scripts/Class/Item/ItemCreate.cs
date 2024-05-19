using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] itemImages;
    private System.Random random;
    private ItemInventory inventory;
    // Prefabs�� �ִ� Item�� Script �޾ƿ�
    public Item items;
    public BreakBrickManager breakBrickManager;

    private int itemIndex;
    private int breakBrickNum;
    private float gameStartTime = 0f;
    private float itemCreateTime = 10.0f;

    private void Awake()
    {
        random = new System.Random();
        inventory = GetComponent<ItemInventory>();
        breakBrickManager = breakBrickManager.GetComponent<BreakBrickManager>();
    }
    private void Start()
    {
         
    }

    private void Update()
    {
        // ���� �ð����� Item ���� (��, ������ �� �� �̻� �ı��� ��쿡�� ������)
        if (gameStartTime < itemCreateTime)
        {
            gameStartTime += Time.deltaTime;
            if (gameStartTime >= itemCreateTime)
            {
                breakBrickNum = breakBrickManager.SetIndex();
                if (breakBrickNum != 0)
                {
                    CreateItems();
                }
                gameStartTime = 0f;
            }
        }
    }

    private void CreateItems()
    {

        breakBrickManager.SetActive(0);

        ////ItemInventory�� �ִ� Item �� �������� ����
        //itemIndex = random.Next(0, inventory.ApplyItems());

        //// Test Paddle Size
        // itemIndex = random.Next(0, 2);

        //// Test Paddle Speed
        // itemIndex = random.Next(2, 4);

        //// Test Ball Size
        // itemIndex = random.Next(4, 6);

        //// Test Ball Speed
        //itemIndex = random.Next(6, 8);

        //// TODO : ������ ���ǻ� Color�� ����, ���� Sprite or Image�� ���� �ʿ�
        //items.GetComponent<SpriteRenderer>().color = itemImages[itemIndex].color;
        //// �ı��� ���� ��ġ �� �������� ����
        //int createItemIndex = random.Next(0, breakBrickNum);
        //// ������ ��ġ�� ��ǥ�� ��������
        //Vector2 createItemPosition = GameManager.Instance.BreakBrick[createItemIndex].GetComponent<Transform>().position;

        //// ������ ������ �� �ش� ���� ��ġ�� ��ǥ�� ����
        //items.GetComponent<Transform>().position = new Vector2(createItemPosition.x, createItemPosition.y);

        //// ������ ����
        //Instantiate(items).CreateItem(
        //inventory.SetItemStatsName(itemIndex), inventory.SetItemStatsId(itemIndex), inventory.SetItemStatsSpeed(itemIndex),
        //inventory.SetItemStatsSize(itemIndex));

        //// ���� �� List���� ���� ���õ� Object ����
        //GameManager.Instance.BreakBrick.RemoveAt(createItemIndex);
    }
}
