using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
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
    public void PlayAgainYesClick()
    {
        Debug.Log("�ٽ� �÷��� �ҰԿ�");
    }
    private void PlayAgainNoClick()
    {
        Debug.Log("�ٽ� �÷��� ����");
    }
}
