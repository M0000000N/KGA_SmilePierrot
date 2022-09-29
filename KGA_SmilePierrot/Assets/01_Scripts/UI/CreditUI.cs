using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditUI : MonoBehaviour
{
    private Transform initTransform;

    [SerializeField]
    private string buttonClick_Sound;
    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);
    }

    public void ExitButtonClick()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        gameObject.SetActive(false);
        UIManager.Instance.MainUI.gameObject.SetActive(true);
    }
}
