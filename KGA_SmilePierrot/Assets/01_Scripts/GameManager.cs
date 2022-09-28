using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int HP;

    public int Stage;
    public int ClickCount;

    public bool CanSelectSkull;

    public Pannel Pannel;
    public Skull Skull;
    public SelectSkull SelectSkull;

    [Header("테스트값")]
    public int MAXSTAGE;
    public float[] LimitTime;
    public float[] PannelDelayTime;

    public bool IsInGame;
    public bool IsPause;

    public void Initialize()
    {
        HP = 5;
        ClickCount = 0;
        Stage = 1;
        IsInGame = false;
        IsPause = false;
        SelectSkull.Initialize();
        UIManager.Instance.InGameUI.RefreshUI();
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
        IsInGame = false;
    }

    public void GameStart() // 랜덤으로 패널 보여주기
    {
        IsInGame = true;
        if (Stage == 1)
        {
            Pannel.StartCoroutine("SetPannelColorCoroutine",1f);
        }
        else
        {
            Pannel.StartCoroutine("SetPannelColorCoroutine",2f);
        }
        ClickCount = 0;
        UIManager.Instance.InGameUI.SetStageText(Stage);
        UIManager.Instance.InGameUI.SetHp(HP);
        Pannel.Initialize();
    }

    public void NextStage()
    {
        if (Stage >= MAXSTAGE) // TODO : 나중에 매직넘버 바꿔주세요.
        {
            // 게임 클리어 씬으로 이동을 하던가 하겠죠
            UIManager.Instance.ClearUI.gameObject.SetActive(true);
            return;
        }

        Stage++;
        SetStage();
    }

    public void SetStage()
    {
        ClickCount = 0;
        UIManager.Instance.InGameUI.SetStageText(Stage);
        Pannel.Initialize();
        Skull.Initialize();
        GameStart();
    }

    public void CheckColor(Color _color)
    {
        if (Pannel.RandomColor[ClickCount] == _color)
        {
            ClickCount++;
            UnityEngine.Debug.Log(ClickCount);
            if(Pannel.RandomColor.Length <= ClickCount)
            {
                NextStage();
            }
        }
        else
        {
            Damaged();
            SetStage();
        }
    }

    public void Pause()
    {
        IsPause = true;
        Time.timeScale = 0;
    }
}
