using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPopUpUI : MonoBehaviour
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
        UIManager.Instance.MainUI.gameObject.SetActive(false);
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);
        Debug.Log("인게임드가자");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
