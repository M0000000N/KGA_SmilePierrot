using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public Transform InitTransform;

    public void Initialize()
    {
        InitTransform = this.transform.parent.transform;

        transform.position = InitTransform.position;
        gameObject.SetActive(true);
    }

    public void GameStartButtonClick()
    {
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(true);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
        Debug.Log("��������");
    }

    public void CreditButtonClick()
    {
        // ���� UI �߰�����
        Debug.Log("����");
    }
}
