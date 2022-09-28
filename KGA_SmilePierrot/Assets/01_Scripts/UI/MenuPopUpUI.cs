using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopUpUI : MonoBehaviour
{
    private Transform initTransform;
    
    [SerializeField] private string buttonClick_Sound;

    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;
        gameObject.SetActive(false);
    }

    public void ResumeButtonCilck()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        gameObject.SetActive(false);
        Time.timeScale = 1;

    }
    public void ExitButtonCilck()
    {
        SoundManager.Instance.setEffect(buttonClick_Sound);
        Debug.Log("���� ����");
    }
}
