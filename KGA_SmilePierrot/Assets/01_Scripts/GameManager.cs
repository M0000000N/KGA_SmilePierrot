using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int HP;
    
    public int Stage;
    public int ClickCount;

    public bool CanSelectSkull;

    public int MAXSTAGE;

    public Pannel pannel;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        HP = 5;
        ClickCount = 0;
        Stage = 1;
    }

    public void Damaged()
    {
        HP--;
        UIManager.Instance.InGameUI.SetHp(HP);
        if (HP <= 0)
        {
            GameOver();
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
            pannel.StartCoroutine("SetPannelColorCoroutine");
            if (Input.GetKeyDown(KeyCode.E))
            {
                // TODO : �������� 1�� E�� ������ ������ �� �ֵ��� ���� �ʿ�
            }
        }
        else
        {
            pannel.StartCoroutine("SetPannelColorCoroutine");
        }
    }

    public void NextStage()
    {
        if(Stage >= MAXSTAGE) // TODO : ���߿� �����ѹ� �ٲ��ּ���.
        {
            // ���� Ŭ���� ������ �̵��� �ϴ��� �ϰ���
            return;
        }

        Stage++;
        ClickCount = 0;
        UIManager.Instance.InGameUI.SetStageText(Stage);
        pannel.Initialize();
        GameStart();
    }

    public void CheckColor(Color _color)
    {
        if (pannel.RandomMaterial[ClickCount].color == _color)
        {
            ClickCount++;
            UnityEngine.Debug.Log(ClickCount);
            if(pannel.RandomMaterial.Length <= ClickCount)
            {
                NextStage();
            }
        }
        else
        {
            Damaged();
            NextStage();
        }
    }
}
