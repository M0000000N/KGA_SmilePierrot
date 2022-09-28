using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
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
    public void YesButtonClick()
    {
        gameObject.SetActive(false);
        SoundManager.Instance.setEffect(buttonClick_Sound);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);
        GameManager.Instance.Initialize();
        GameManager.Instance.IsInGame = true;

        Debug.Log("다시 플레이 할게요");
    }
    public void NoButtonClick()
    {
        gameObject.SetActive(false);
        SoundManager.Instance.setEffect(buttonClick_Sound);
        UIManager.Instance.MainUI.gameObject.SetActive(true);

        Debug.Log("다시 플레이 안해");
    }
}

