using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int Stage = 1;
    public void ChangeNextStage()
    {

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
