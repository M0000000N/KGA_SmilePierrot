using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditUI : MonoBehaviour
{
    private Transform initTransform;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);
    }

    public void ExitButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainUI.gameObject.SetActive(true);
    }
}
