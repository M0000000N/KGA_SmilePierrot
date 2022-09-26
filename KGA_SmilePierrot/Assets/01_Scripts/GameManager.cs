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
        else // [Issue1]틀리면 바로 다음 스테이지가 맞는지 확인
        {
            NextStage();
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
            Debug.Log("Stage == 1 들어오냐");
                pannel.StartCoroutine("SetPannelColorCoroutine");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Input.GetKeyDown(KeyCode.E) 들어오냐");
            }
        }
        else
        {
            Debug.Log("else 들어오냐");
            pannel.StartCoroutine("SetPannelColorCoroutine");
        }
    }

    public void NextStage()
    {
        Stage++;
        UnityEngine.Debug.Log("현재 스테이지 : " + Stage);
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
