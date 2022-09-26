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
        Debug.Log("다시 플레이 할게요");
    }
    private void PlayAgainNoClick()
    {
        Debug.Log("다시 플레이 안해");
    }
}
