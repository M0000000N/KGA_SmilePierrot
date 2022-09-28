using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private Transform initTransform;

    [SerializeField]
    private string gameOver_Sound;

    [SerializeField]
    private string buttonClick_Sound;
    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);
    }
    public void YesButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);
        GameManager.Instance.Initialize();
        GameManager.Instance.IsInGame = true;

        SoundManager.Instance.setEffect(buttonClick_Sound);
        GameManager.Instance.IsCursorOn(false);
    }
    public void NoButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainUI.gameObject.SetActive(true);
        SoundManager.Instance.setEffect(buttonClick_Sound);
    }
}
