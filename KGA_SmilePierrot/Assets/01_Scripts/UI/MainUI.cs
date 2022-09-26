using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public Transform InitTransform;

    public void Initialize()
    {
        transform.position = InitTransform.position;
        gameObject.SetActive(true);
    }

    public void GameStartButtonClick()
    {
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(true);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }

    public void CreditButtonClick()
    {
        // 제작 UI 추가예정
        Debug.Log("제작");
    }
}
