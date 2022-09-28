using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Pannel : MonoBehaviour
{
    private Renderer pannelRenderer;
    // private Material[] ResourceMaterial; // ���ҽ��������� ������ ��
    private TextMeshPro colorText;
    // private string[]colorTextArray = new string[] { "RED", "BLUE", "GREEN", "WHITE"};

    public float delayTime;

    // public int RememberCount; // TODO : CSV���� �����;� �մϴ�. 

    public Color PannelColor; // ���� �г� �÷�
    public Color[] RandomColor; // �������� ����� ��

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
        int[] isdone = new int[int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count)]; // �׽�Ʈ ī��Ʈ 4 => 0 ~ 3
        UIManager.Instance.InGameUI.AnswerText.text = "�� : ";

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
        Debug.Log("�������!");
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


