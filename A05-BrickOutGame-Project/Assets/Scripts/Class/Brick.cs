using UnityEngine;

public class Brick :MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int Score;

    private BrickUI brickUI;
    private void Awake()
    {
        brickUI = GetComponent<BrickUI>();
        brickUI.UpdateBrickHPTxt(HP);
    }

    private void GetAttack(int damage)
    {
        HP -= damage;
        if (HP <= 0 )
        {
            HP = 0;
            // TODO ::  AddScore(Score) & ������ƮǮ ����
        }
        brickUI.UpdateBrickHPTxt( HP );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO :: ������ ���� ����Ͽ� ���� �������� �þ�� �� ����
        GetAttack(1);
    }
}
