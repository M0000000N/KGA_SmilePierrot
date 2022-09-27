using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPopUpUI : MonoBehaviour
{
    private Transform initTransform;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);
    }

    public void GameStartButtonClick()
    {
        gameObject.SetActive(false);
        UIManager.Instance.MainUI.gameObject.SetActive(false);
        UIManager.Instance.InGameUI.gameObject.SetActive(true);

        Debug.Log("게임시작");
        Camera.main.transform.localEulerAngles = Vector3.zero;
        // GameManager.Instance.GameStart(); // 팝업만 닫히고 Start는 지팡이와 상호작용한 후로 변경
    }
}
