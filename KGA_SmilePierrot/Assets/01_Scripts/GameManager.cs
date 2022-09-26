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

        UIManager.Instance.HP.text = "HP : " + HP.ToString();
        UIManager.Instance.Stage.text = "Stage : " + Stage.ToString();
    }

    public void Damaged()
    {
        HP--;
        UIManager.Instance.HP.text = "HP : " + HP.ToString();

        UnityEngine.Debug.Log("HP : " + HP);
        if( HP <= 0)
        {
            // ���ӿ���
            UnityEngine.Debug.Log("���ӿ���");
            UIManager.Instance.Log.text = "���� ����";

        }
        else
        {
            NextStage();
            UnityEngine.Debug.Log("���� �������� : " + Stage);
            // ���� ��������
        }
    }

    public void NextStage()
    {
        Stage++;
        UIManager.Instance.Stage.text = "Stage : " + Stage.ToString();
    }

    public bool IsRightColor(int _colorType)
    {
        if(true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
