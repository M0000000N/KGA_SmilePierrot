using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public Transform InitTransform;

    public void Initialize()
    {
        InitTransform = this.transform.parent.transform;

        transform.position = InitTransform.position;
        gameObject.SetActive(false);
    }
    public void YesButtonClick()
    {
        Debug.Log("�ٽ� �÷��� �ҰԿ�");
    }
    public void NoButtonClick()
    {
        Debug.Log("�ٽ� �÷��� ����");
    }
}
