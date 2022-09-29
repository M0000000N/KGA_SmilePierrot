using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPopUpUI : MonoBehaviour
{
    private Transform initTransform;

    [SerializeField] private string buttonClick_Sound;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);
    }

    public void GameStartButtonClick()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        gameObject.SetActive(false);
        UIManager.Instance.MainUI.gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);

        Debug.Log("게임시작");
        GameManager.Instance.Initialize();
        GameManager.Instance.IsInGame = true;
    }
}
