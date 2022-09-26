using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int HP;
    public int Stage;

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        HP = 3;
        Stage = 1;
    }

    public void Damaged()
    {
        HP--;
        UnityEngine.Debug.Log("HP : " + HP);
        if( HP <= 0)
        {
            // ���ӿ���
            UnityEngine.Debug.Log("���ӿ���");
        }
        else
        {
            Stage++;
            UnityEngine.Debug.Log("���� �������� : " + Stage);
            // ���� ��������
        }
    }

    public void NextStage()
    {
        Stage++;
    }

    public bool IsRightColor(int _colorType)
    {
        if(true) // ���� �÷��̾� ���� ����(_colorType)�� CSV ��� ���ϴ� �ڵ� �߰� �ʿ�
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
