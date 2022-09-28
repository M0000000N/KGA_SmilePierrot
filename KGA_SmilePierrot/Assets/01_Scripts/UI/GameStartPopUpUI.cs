using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPopUpUI : MonoBehaviour
{
    public Transform InitTransform;

    [SerializeField]
    private string buttonClick_Sound;
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
        SoundManager.Instance.setEffect(buttonClick_Sound);

        Debug.Log("게임시작");
        GameManager.Instance.GameStart();

    }
}
