using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOverUI : MonoBehaviour
{
    private Transform initTransform;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(true);
    }
    public void YesButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);
        GameManager.Instance.Initialize();
        GameManager.Instance.GameStart();
    }
    public void NoButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainUI.gameObject.SetActive(true);
    }
}
