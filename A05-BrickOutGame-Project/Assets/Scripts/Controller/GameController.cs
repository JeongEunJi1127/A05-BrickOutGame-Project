using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;   //�׼ǿ� ���� �̺�Ʈ ����
    public event Action<Vector2> OnLookEvent;


    public void CallMoveEvent(Vector2 direction)      //�̺�Ʈ�� invoke ��Ű�� �Լ�
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction) 
    { 
        OnLookEvent?.Invoke(direction); 
    }       
}
