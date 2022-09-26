using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public Transform InitTransform;

    public void Initialize()
    {
        transform.position = InitTransform.position;
        gameObject.SetActive(false);
    }
    public void YesButtonClick()
    {
        Debug.Log("다시 플레이 할게요");
    }
    public void NoButtonClick()
    {
        Debug.Log("다시 플레이 안해");
    }
}
