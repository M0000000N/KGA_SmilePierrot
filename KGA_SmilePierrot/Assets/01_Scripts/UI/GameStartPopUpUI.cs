using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPopUpUI : MonoBehaviour
{
    public Transform InitTransform;

    public void Initialize()
    {
        InitTransform = this.transform.parent.transform;

        transform.position = InitTransform.position;
        gameObject.SetActive(false);
    }

    public void GameStartButtonClick()
    {
        UIManager.Instance.MainUI.gameObject.SetActive(false);
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);

        Debug.Log("���ӽ���");
        GameManager.Instance.GameStart();

    }
}