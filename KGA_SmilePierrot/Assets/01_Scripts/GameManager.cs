using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int HP;
    public int Stage;
    public Pannel pannel;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        HP = 5;
        Stage = 1;
    }

    public void Damaged()
    {
        HP--;
        UIManager.Instance.InGameUI.SetHp(HP);

        UnityEngine.Debug.Log("HP : " + HP);
        if (HP <= 0)
        {
            GameOver();
        }
        else // [Issue1]Ʋ���� �ٷ� ���� ���������� �´��� Ȯ��
        {
            NextStage();
        }
    }

    public void GameOver()
    {
        UnityEngine.Debug.Log("���ӿ���");
        UIManager.Instance.InGameUI.gameObject.SetActive(false);
        UIManager.Instance.GameOverUI.gameObject.SetActive(true);
    }

    public void GameStart() // �������� �г� �����ֱ�
    {
        if (Stage == 1)
        {
            Debug.Log("Stage == 1 ������");
                pannel.StartCoroutine("SetPannelColorCoroutine");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Input.GetKeyDown(KeyCode.E) ������");
            }
        }
        else
        {
            Debug.Log("else ������");
            pannel.StartCoroutine("SetPannelColorCoroutine");
        }
    }

    public void NextStage()
    {
        Stage++;
        UnityEngine.Debug.Log("���� �������� : " + Stage);
        UIManager.Instance.InGameUI.SetStageText(Stage);
        pannel.Initialize();
        GameStart();

    }

    //public bool IsRightColor(int _colorType)
    //{
    //    if (true)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
