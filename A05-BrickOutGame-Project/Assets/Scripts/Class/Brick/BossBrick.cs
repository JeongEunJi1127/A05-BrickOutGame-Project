using System;
using UnityEngine;

public class BossBrick : Brick
{
    private BossAttack bossAttack;

    protected override void Awake()
    {
        base.Awake();

        bossAttack = GetComponent<BossAttack>();
        BossInit();
    }
    private void Start()
    {
        brickUI.UpdateBrickHPTxt(HP);
    }

    private void BossInit()
    {
        SetHP(100);
        SetScore(100);
    }

    // ���� HP�� ���� ���� Skill ����
    private void CheckBossHP()
    {
        // HP 70, 30 �� ��  -  Blind Skill
        if (HP == 70 || HP == 30)
        {
            bossAttack.BlindSkill();
        }
        // HP 50�� �� - Shield Skill
        if  (HP == 50)
        {
            bossAttack.ShieldSkill();
        }
    }

    private void BossDie()
    {
        // TODO :: EndingManager ����
    }

    public void SetBreakBossBrickManager(BrickManager breakBrick)
    {
        brickManager = breakBrick;
    }

    protected override void BrickBreak()
    {
        BossDie();
        brickManager.GetBrickScore(Score);
        gameObject.SetActive(false);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        CheckBossHP();
    }

}
