using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUpUI : MonoBehaviour
{
    public Transform InitTransform;

    public void Initialize()
    {
        InitTransform = this.transform.parent.transform;

        transform.position = InitTransform.position;
        gameObject.SetActive(false);
    }

    public void ResumeButtonCilck()
    {
        Debug.Log("게임 재개");
        gameObject.SetActive(false);
        Time.timeScale = 1;

    }
    public void ExitButtonCilck()
    {
        Debug.Log("게임 종료");
    }
}
