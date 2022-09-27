using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private Transform initTransform;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(true);
    }

    public void GameStartButtonClick()
    {
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(true);
        GameManager.Instance.Initialize();
        GameManager.Instance.GameStart();
    }

    public void ExitButtonClick()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

    public void CreditButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.CreditUI.gameObject.SetActive(true);
    }
}
