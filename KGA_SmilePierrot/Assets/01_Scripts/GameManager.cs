using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void ChangeNextStage()
    {

    }

    public bool IsRightColor(int _colorType)
    {
        if(true) // 추후 플레이어 선택 색상(_colorType)과 CSV 답과 비교하는 코드 추가 필요!!
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
