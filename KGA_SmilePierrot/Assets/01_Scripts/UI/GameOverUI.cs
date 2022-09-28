using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public Transform InitTransform;

    [SerializeField]
    private string gameOver_Sound;

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
        SoundManager.Instance.setEffect(buttonClick_Sound);
        Debug.Log("�ٽ� �÷��� �ҰԿ�");
    }
    public void NoButtonClick()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        Debug.Log("�ٽ� �÷��� ����");
    }
}

