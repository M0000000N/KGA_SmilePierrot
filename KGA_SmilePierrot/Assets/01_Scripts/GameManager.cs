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
        UnityEngine.Debug.Log("게임오버");
        UIManager.Instance.InGameUI.gameObject.SetActive(false);
        UIManager.Instance.GameOverUI.gameObject.SetActive(true);
    }

    public void GameStart() // 랜덤으로 패널 보여주기
    {
        if (Stage == 1)
        {
            pannel.StartCoroutine("SetPannelColorCoroutine");
            if (Input.GetKeyDown(KeyCode.E))
            {
                // TODO : 스테이지 1은 E를 눌러야 시작할 수 있도록 변경 필요
            }
        }
        else
        {
            pannel.StartCoroutine("SetPannelColorCoroutine");
        }
    }

    public void NextStage()
    {
        if(Stage >= MAXSTAGE) // TODO : 나중에 매직넘버 바꿔주세요.
        {
            // 게임 클리어 씬으로 이동을 하던가 하겠죠
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
