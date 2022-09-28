using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    private Transform initTransform;
    public Image[] HPImages;
    public Slider ProgressBar;
    public Text StageText;
    public Text AnswerText;


    public void Initialize()
    {
        initTransform = this.transform.parent.transform;
        transform.position = initTransform.position;

        gameObject.SetActive(false);

        RefreshUI();
    }

    public void RefreshUI()
    {
        SetStageText(GameManager.Instance.Stage);
        SetHp(GameManager.Instance.HP);
        ProgressBar.value = 1;
    }

    private void Update()
    {
        if (GameManager.Instance.CanSelectSkull)
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
        if (_hp == HPImages.Length) // 초기화 할 때
        {
            for (int i = 0; i < _hp; i++)
            {
                HPImages[i].gameObject.SetActive(true);
            }
        }
        else // 하나씩 떨어질 경우에만 해당
        {
            HPImages[_hp].gameObject.SetActive(false);
        }
    }

    public void StartTimeLimit()
    {
        ProgressBar.value -= Time.deltaTime / GameManager.Instance.LimitTime[GameManager.Instance.Stage - 1];
        if (ProgressBar.value <= 0)
        {
            GameManager.Instance.Damaged();
            GameManager.Instance.SetStage();
            return;
        }
    }
}
