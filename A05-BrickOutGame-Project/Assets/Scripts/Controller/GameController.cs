using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;   //�׼ǿ� ���� �̺�Ʈ ����
    public event Action<Vector2> OnAimEvent;


    public void CallMoveEvent(Vector2 direction)      //�̺�Ʈ�� invoke ��Ű�� �Լ�
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallAimEvent(Vector2 direction) 
    { 
        OnAimEvent?.Invoke(direction); 
    }       
}
