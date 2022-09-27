using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPopUpUI : MonoBehaviour
{
    private Transform initTransform;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);
    }

    public void GameStartButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainUI.gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);

        GameManager.Instance.GameStart();
    }
}
