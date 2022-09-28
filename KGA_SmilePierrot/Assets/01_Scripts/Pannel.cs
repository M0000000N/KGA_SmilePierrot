using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Pannel : MonoBehaviour
{
    Renderer pannelRenderer;

    public Color PannelColor; // 현재 패널 컬러
    public Color[] RandomColor; // 랜덤으로 저장될 색

    void Awake()
    {
        pannelRenderer = transform.GetChild(0).GetComponent<MeshRenderer>(); ;
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        GameManager.Instance.CanSelectSkull = false;
        RandomColor = new Color[int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count)];
        pannelRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);

        SetRandomRememberColor();
    }

    public void SetRandomRememberColor()
    {
        UIManager.Instance.InGameUI.AnswerText.text = "답 : ";

        int rememberCount = int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count);
        int[] isdone = new int[rememberCount];

        for (int i = 0; i < rememberCount; i++)
        {
            int randNum = Random.Range(0, rememberCount);
            isdone[i] = randNum;

            if (i >= 2)
            {
                while (isdone[i] == isdone[i - 1] && isdone[i] == isdone[i - 2])
                {
                    randNum = Random.Range(0, rememberCount);
                    isdone[i] = randNum;
                }
            }

            RandomColor[i] = GameManager.Instance.Skull.skulls[randNum].GetComponent<Renderer>().material.color;
            UIManager.Instance.InGameUI.AnswerText.text += GameManager.Instance.Skull.skulls[randNum].name + " / ";
        }
    }

    public IEnumerator SetPannelColorCoroutine(float _startTime)
    {
        int index = 0;
        yield return new WaitForSeconds(_startTime);

        while (index < int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count))
        {
            pannelRenderer.material.color = new Color(0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.2f);

            SetPannelColor(index);
            yield return new WaitForSeconds(GameManager.Instance.PannelDelayTime[GameManager.Instance.Stage - 1]);

            index++;
        }
        GameManager.Instance.CanSelectSkull = true;
        Debug.Log("맞춰봐라!");
        UIManager.Instance.InGameUI.StartTimeLimit();
        yield break;
    }

    private void SetPannelColor(int _index)
    {
        PannelColor = RandomColor[_index];
        pannelRenderer.material.color = PannelColor;
    }
}


