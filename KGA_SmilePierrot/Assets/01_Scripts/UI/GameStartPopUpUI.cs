using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPopUpUI : MonoBehaviour
{
    public Transform InitTransform;

    public void Initialize()
    {
        InitTransform = this.transform.parent.transform;

        transform.position = InitTransform.position;
        gameObject.SetActive(false);
    }

    public void GameStartButtonClick()
    {
        UIManager.Instance.MainUI.gameObject.SetActive(false);
        UIManager.Instance.GameStartPopUpUI.gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);

        Debug.Log("게임시작");
        Camera.main.transform.localEulerAngles = Vector3.zero;
        // GameManager.Instance.GameStart(); // 팝업만 닫히고 Start는 지팡이와 상호작용한 후로 변경
    }
}
