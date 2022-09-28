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
    public PlayController PlayController;

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
        
        IsPause = false;
        CanSelectSkull = false;
        SelectSkull.Initialize();
        PlayController.Initialize();
        Skull.Initialize();
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
        else
        {
            GameStart();
        }
    }

    public void GameOver()
    {
        UnityEngine.Debug.Log("게임오버");
        UIManager.Instance.InGameUI.gameObject.SetActive(false);
        UIManager.Instance.GameOverUI.gameObject.SetActive(true);
        Pannel.StopAllCoroutines();
        IsInGame = false;
    }

    public void GameStart() // 랜덤으로 패널 보여주기
    {
        Pannel.Initialize();
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
    }

    public void NextStage()
    {
        if (Stage >= MAXSTAGE) // TODO : 나중에 매직넘버 바꿔주세요.
        {
            UIManager.Instance.ClearUI.gameObject.SetActive(true);
            return;
        }

        Stage++;
        SetStage();
        GameStart();
    }

    public void SetStage()
    {
        ClickCount = 0;
        UIManager.Instance.InGameUI.SetStageText(Stage);
        Pannel.Initialize();
        Skull.Initialize();
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
