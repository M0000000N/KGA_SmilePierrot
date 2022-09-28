using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Pannel : MonoBehaviour
{
    private Renderer pannelRenderer;
    // private Material[] ResourceMaterial; // 리소스폴더에서 가져올 색
    private TextMeshPro colorText;
    // private string[]colorTextArray = new string[] { "RED", "BLUE", "GREEN", "WHITE"};

    public float delayTime;

    // public int RememberCount; // TODO : CSV에서 가져와야 합니다. 

    public Color PannelColor; // 현재 패널 컬러
    public Color[] RandomColor; // 랜덤으로 저장될 색

    // private List<int> csvColorIndex;

    private void Awake()
    {
        pannelRenderer = transform.GetChild(0).GetComponent<MeshRenderer>(); ;
        colorText = GetComponentInChildren<TextMeshPro>();
    }
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        GameManager.Instance.CanSelectSkull = false;
        
        // csvColorIndex = CSVParser.Instance.GetColorIndex(GameManager.Instance.Stage);
        // ResourceMaterial = Resources.LoadAll<Material>("MaterialColor");
        RandomColor = new Color[int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count)];

        SetRandomRememberColor();
    }

    public void SetRandomRememberColor()
    {
        int[] isdone = new int[int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count)]; // 테스트 카운트 4 => 0 ~ 3
        UIManager.Instance.InGameUI.AnswerText.text = "답 : ";

        for (int i = 0; i < int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count); i++)
        {
            int randNum = Random.Range(0, int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count));
            isdone[randNum]++;
            //if (isdone[randNum] > 2)
            //{
            //    i--;
            //    continue;
            //}
            UnityEngine.Debug.Log(GameManager.Instance.Skull.skulls[randNum]);
            UnityEngine.Debug.Log(GameManager.Instance.Skull.skulls[randNum].GetComponent<Renderer>().material.color);
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
            // colorText.text = colorTextArray[int.Parse(pannelColor.name) - 1];
            yield return new WaitForSeconds(delayTime);

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
        // pannelRenderer.sharedMaterial.SetTextureOffset("_MainTex", Vector2.one);
    }
}


