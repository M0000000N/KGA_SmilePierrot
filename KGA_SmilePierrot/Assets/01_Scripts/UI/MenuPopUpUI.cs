using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUpUI : MonoBehaviour
{
    private Transform initTransform;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);
    }

    public void ResumeButtonCilck()
    {
        gameObject.SetActive(false);
        GameManager.Instance.IsCursorOn(false);
        GameManager.Instance.IsPause = false;
        Time.timeScale = 1;
    }
    public void ExitButtonCilck()
    {
        Debug.Log("게임 종료");
    }
}
