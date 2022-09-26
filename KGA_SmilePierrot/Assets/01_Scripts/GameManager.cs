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
            // 게임오버
            UnityEngine.Debug.Log("게임오버");
        }
        else
        {
            Stage++;
            UnityEngine.Debug.Log("현재 스테이지 : " + Stage);
            // 다음 스테이지
        }
    }

    public void NextStage()
    {
        Stage++;
    }

    public bool IsRightColor(int _colorType)
    {
        if(true) // 추후 플레이어 선택 색상(_colorType)과 CSV 답과 비교하는 코드 추가 필요
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
