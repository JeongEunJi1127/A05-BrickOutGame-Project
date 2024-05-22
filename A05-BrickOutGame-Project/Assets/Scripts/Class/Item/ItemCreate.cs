using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemObjects;
    [SerializeField] private BrickManager brickManager;
    private System.Random random;
    private ItemInventory inventory;
    // Prefabs�� �ִ� Item�� Script �޾ƿ�
    public Item items;
    // BrickManager���� ScoreBoardUI �޾ƿ�
    private ScoreBoardUI scoreBoard;

    private int itemIndex;
    private int breakBrickNum;
    private int createItemIndex;
    private float gameStartTime = 0f;
    private float itemCreateTime;

    private void Awake()
    {
        random = new System.Random();
        inventory = GetComponent<ItemInventory>();
        brickManager = brickManager.GetComponent<BrickManager>();
        scoreBoard = brickManager.SetScoreBoardComponent();
    }

    private void Start()
    {
        itemCreateTime = (scoreBoard.SetLevelPlayTime(GameManager.Instance.nowStageNum)/6);
    }

    private void Update()
    {
        // ���� �ð����� Item ���� (��, ������ �� �� �̻� �ı��� ��쿡�� ������)
        // ���� �ı��� ���� ���� ����, ���� �������� ���� �� ���� �ִ�.
        if (gameStartTime < itemCreateTime)
        {
            gameStartTime += Time.deltaTime;
            if (gameStartTime >= itemCreateTime)
            {
                breakBrickNum = brickManager.SetIndex();
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
        //ItemInventory�� �ִ� Item �� �������� ����
        itemIndex = random.Next(0, inventory.ApplyItems());

        // GameObject�� �����ص״� ������ ����
        GameObject item = Instantiate(ItemObjects[itemIndex]);

        // �ı��� ���� ��ġ �� �������� ����
        while (true)
        {
            createItemIndex = random.Next(0, breakBrickNum);

            if (!brickManager.SetIsCreatedBrick(createItemIndex) && !brickManager.SetIsCreatedItem(createItemIndex))
            {
                break;
            }
        }

        // ������ ��ġ�� ��ǥ�� ��������
        Vector2 createItemPosition = brickManager.SetPosition(createItemIndex);

        // ������ �����ϰ� ���� ��ġ�� ���õ� ���� ��ġ�� ��ǥ������ ����
        item.transform.position = new Vector2(createItemPosition.x, createItemPosition.y);

        // ������ ��ġ����
        item.GetComponent<Item>().CreateItem(
        inventory.SetItemStatsName(itemIndex), inventory.SetItemStatsId(itemIndex), inventory.SetItemStatsSpeed(itemIndex),
        inventory.SetItemStatsSize(itemIndex), createItemIndex);

        brickManager.GetIsCreatedItem(createItemIndex, true);
    }
}
