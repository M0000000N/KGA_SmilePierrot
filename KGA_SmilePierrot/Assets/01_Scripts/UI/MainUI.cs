using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private Transform initTransform;

    [SerializeField]
    private string buttonClick_Sound;
    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(true);
    }

    public void GameStartButtonClick()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(true);
    }

    public void ExitButtonClick()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        Debug.Log("게임종료");
        Application.Quit();
    }

    public void CreditButtonClick()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        gameObject.SetActive(false);
        UIManager.Instance.CreditUI.gameObject.SetActive(true);
    }
}
