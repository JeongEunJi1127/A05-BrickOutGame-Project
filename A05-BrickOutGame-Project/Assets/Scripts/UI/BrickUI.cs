using TMPro;
using UnityEngine;

public class BrickUI : MonoBehaviour
{
    [SerializeField] private TMP_Text brickHP;
    public Sprite[] sprites;

    public void UpdateBrickHPTxt(int HP)
    {
        brickHP.text = HP.ToString();
    } 

    public SpriteRenderer SetSprite(SpriteRenderer spriteRenderer, int idx)
    {
        spriteRenderer.sprite = sprites[idx];
        //SetSpriteSize(spriteRenderer);
        return spriteRenderer; 
    }

    //public void SetSpriteSize(SpriteRenderer spriteRenderer)
    //{
    //    // ������ ũ��
    //    float brickWidth = 1.0f;
    //    float brickHeight = 0.4f;

    //    // ��������Ʈ�� ũ��
    //    float spriteWidth = spriteRenderer.sprite.bounds.size.x;
    //    float spriteHeight = spriteRenderer.sprite.bounds.size.y;

    //    // ��������Ʈ�� ũ�⸦ ������ ũ�⿡ ���߱� ���� ���� ���
    //    float scaleX = brickWidth / spriteWidth;
    //    float scaleY = brickHeight / spriteHeight;

    //    // ��������Ʈ�� ũ�⸦ ������ ũ�⿡ �°� ����
    //    spriteRenderer.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
    //}
}
