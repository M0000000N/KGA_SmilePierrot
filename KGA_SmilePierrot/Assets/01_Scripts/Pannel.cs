//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Pannel : MonoBehaviour
{
    private Renderer pannelRenderer;
    private Material[] ResourceMaterial; // 리소스폴더에서 가져올 색
    private TextMeshPro colorText;
    private string[]colorTextArray = new string[] { "RED", "BLUE", "GREEN", "WHITE"};

    public float delayTime;

    public int RememberCount;

    public Material pannelColor; // 현재 패널 컬러
    public Material[] RandomMaterial; // 랜덤으로 저장될 색
    public bool ShowAll;

    private List<int> csvColorIndex;

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
        ShowAll = false;
        
        csvColorIndex = CSVParser.Instance.GetColorIndex(GameManager.Instance.Stage);
        ResourceMaterial = Resources.LoadAll<Material>("MaterialColor");
        RandomMaterial = new Material[RememberCount];

        SetRandomRememberColor();
        StartCoroutine("SetPannelColorCoroutine");
    }

    public void SetRandomRememberColor()
    {
        int[] isDone = new int[ResourceMaterial.Length]; // 4개 컬러중 3번 이상 안나오도록

        for (int i = 0; i < RememberCount; i++)
        {
            int randNum = csvColorIndex[Random.Range(0, csvColorIndex.Count)];
            isDone[randNum - 1]++;
            if (isDone[randNum - 1] > 2)
            {
                i--;
                continue;
            }
            RandomMaterial[i] = ResourceMaterial[randNum - 1];
        }
    }

    IEnumerator SetPannelColorCoroutine()
    {
        int index = 0;
        UIManager.Instance.답.text = "답 : ";
        while (index < RememberCount)
        {
            SetPannelColor(index);
            colorText.text = colorTextArray[int.Parse(pannelColor.name) - 1];
            Debug.Log(index + "번째 색상 : " + pannelColor);
            UIManager.Instance.답.text += $"{pannelColor.name} / ";
            yield return new WaitForSeconds(delayTime);
            index++;
        }
        ShowAll = true;
        Debug.Log("멈춘다");
        yield break;
    }

    private void SetPannelColor(int _index)
    {
        pannelColor = RandomMaterial[_index];
        pannelRenderer.sharedMaterial = pannelColor;
        pannelRenderer.sharedMaterial.SetTextureOffset("_MainTex", Vector2.one);
    }
}

// 상황에 맞지 않은 컴포넌트 사용
// 정상 로직 아님 // material 탐색하면서 비용발생 // 차라리 transform 비교 
// Best 비교 
// Enum 열거형으로 비교 
