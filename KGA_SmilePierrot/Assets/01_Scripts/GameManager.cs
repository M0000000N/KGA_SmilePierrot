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

    [SerializeField] private string GameOver_Sound;
    [SerializeField] private string GameScene_Sound;
    [SerializeField] private string GameClear_Sound;
    [SerializeField] private string Right_Sound;
    [SerializeField] private string Wrong_Sound;

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
        PlayBGM(); 
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
        SoundManager.Instance.BGM.Stop();
        SoundManager.Instance.setEffect(GameOver_Sound);
        UIManager.Instance.InGameUI.gameObject.SetActive(false);
        UIManager.Instance.GameOverUI.gameObject.SetActive(true);
        GameManager.Instance.IsCursorOn(true);
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
        Stage++;

        if (Stage > MAXSTAGE) // TODO : 나중에 매직넘버 바꿔주세요.
        {
            SoundManager.Instance.BGM.Stop();
            SoundManager.Instance.setEffect(GameClear_Sound);
            UIManager.Instance.ClearUI.gameObject.SetActive(true);
            GameManager.Instance.IsCursorOn(true);
            return;
        }

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
            SoundManager.Instance.setEffect(Right_Sound);
            ClickCount++;
            UnityEngine.Debug.Log(ClickCount);
            if(Pannel.RandomColor.Length <= ClickCount)
            {
                NextStage();
            }
        }
        else
        {
            SoundManager.Instance.setEffect(Wrong_Sound);
            Damaged();
            SetStage();
        }
    }

    public void Pause()
    {
        IsPause = true;
        Time.timeScale = 0;
    }

    public void PlayBGM()
    {
        SoundManager.Instance.SetBGM(GameScene_Sound);
    }

    public void IsCursorOn(bool _isOn)
    {
        if(_isOn)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
