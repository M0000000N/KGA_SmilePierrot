using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Transform InitTransform;
    public Image[] HPImages;
    public Slider ProgressBar;
    public Text StageText;
    public Text AnswerText;


    public void Initialize()
    {
        transform.position = InitTransform.position;
        gameObject.SetActive(false);

        SetStageText(1);
        SetHp(HPImages.Length);
        ProgressBar.value = 1;
    }
    private void Update()
    {
        if (GameManager.Instance.pannel.ShowAll)
        {
            StartTimeLimit();
        }
        else
        {
            ProgressBar.value = 1;
        }
    }

    public void SetStageText(int _stage)
    {
        StageText.text = "Stage : " + _stage;
    }

    public void SetHp(int _hp)
    {
        if (_hp == HPImages.Length) // �ʱ�ȭ �� ��
        {
            for (int i = 0; i < _hp; i++)
            {
                HPImages[i].gameObject.SetActive(true);
            }
        }
        else // �ϳ��� ������ ��쿡�� �ش�
        {
            HPImages[_hp].gameObject.SetActive(false);
        }
    }

    public void StartTimeLimit()
    {
        ProgressBar.value -= Time.deltaTime / 10;//csv���� ������ ���Ѽ��ڰ�
        if (ProgressBar.value <= 0)
        {
            GameManager.Instance.GameOver();
            return;
        }
    }
}
