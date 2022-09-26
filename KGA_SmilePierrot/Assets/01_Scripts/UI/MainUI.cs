using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public Transform InitTransform;
    private void Awake()
    {
        transform.position = InitTransform.position;
    }
    private void Start()
    {
        Initionalize();
    }
    public void Initionalize()
    {
        gameObject.SetActive(false);
    }
    public void GameStartButtonClick()
    {
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(true);
        Debug.Log("���ӽ�ŸƮ");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
        Debug.Log("��������");
    }

    public void CreditButtonClick()
    {
        // ���� UI �Ƹ� �߰�
        Debug.Log("����");
    }
}
