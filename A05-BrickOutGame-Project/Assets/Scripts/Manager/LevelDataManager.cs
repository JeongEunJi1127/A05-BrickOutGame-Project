using System.IO;
using UnityEditor.EditorTools;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    private ObjectPoolManager poolManager;
    private BrickTypeList brickTypeList;
    [SerializeField] private BrickManager brickManager;

    private void Awake()
    {
        brickManager = brickManager.GetComponent<BrickManager>();
        poolManager = GetComponent<ObjectPoolManager>();    
    }
    private void Start()
    {
        LoadData();
        LevelPoolSpawn();
    }

    private void LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, $"level{GameManager.Instance.stageNum}.json");
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            brickTypeList = JsonUtility.FromJson<BrickTypeList>(dataAsJson);
        }
    }

    private void LevelPoolSpawn()
    {
        int idx = 0;
        for (int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                // brickTypeList���� ���� ���� �ҷ�����
                int brickType = brickTypeList.brickTypes[idx].Type;
                var brickInfo = brickManager.BrickTypes(brickType);
                // brickInfo ���� ���� ������ �� �־��ֱ�
                if (!brickManager.BrickTypes(brickType).IsActive)
                {
                    poolManager.DisableObj(poolManager.pool[i, j]);
                }
                else
                {
                    Brick brick = poolManager.pool[i, j].GetComponent<Brick>();
                    if (brick != null)
                    {
                        brick.SetHP(brickInfo.HP);
                        brick.SetScore(brickInfo.Score);
                        brick.SetSpriteRenderer(brickInfo.SpriteIdx);

                        // �� ������ ������ brickManager�� �־��ֱ�
                        brick.GetBreakBrickManager(brickManager);
                    }
                }
                idx += 1;
            }
        }
    }
}