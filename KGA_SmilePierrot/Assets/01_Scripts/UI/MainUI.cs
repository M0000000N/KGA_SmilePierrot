using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public Transform InitTransform;
    private void Awake()
    {
        transform.position = InitTransform.position;
    }
    private void Start()
    {
        Initionalize();
    }
    public void Initionalize()
    {
        gameObject.SetActive(false);
    }
    public void GameStartButtonClick()
    {
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(true);
        Debug.Log("게임스타트");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }

    public void CreditButtonClick()
    {
        // 제작 UI 아마 추가
        Debug.Log("제작");
    }
}
