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
        GameManager.Instance.CanSelectSkull = false;
        
        csvColorIndex = CSVParser.Instance.GetColorIndex(GameManager.Instance.Stage);
        ResourceMaterial = Resources.LoadAll<Material>("MaterialColor");
        RandomMaterial = new Material[RememberCount];

        SetRandomRememberColor();
    }

    public void SetRandomRememberColor()
    {
        int[] isdone = new int[ResourceMaterial.Length]; // 4개 컬러중 3번 이상 안나오도록

        for (int i = 0; i < RememberCount; i++)
        {
            int randNum = csvColorIndex[Random.Range(0, csvColorIndex.Count)];
            isdone[randNum - 1]++;
            if (isdone[randNum - 1] > 2)
            {
                i--;
                continue;
            }
            RandomMaterial[i] = ResourceMaterial[randNum - 1];
        }
    }

    public IEnumerator SetPannelColorCoroutine()
    {
        int index = 0;
        UIManager.Instance.InGameUI.AnswerText.text = "답 : ";
        while (index < RememberCount)
        {
            SetPannelColor(index);
            colorText.text = colorTextArray[int.Parse(pannelColor.name) - 1];
            UIManager.Instance.InGameUI.AnswerText.text += pannelColor.name + " / ";
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
        pannelColor = RandomMaterial[_index];
        pannelRenderer.sharedMaterial = pannelColor;
        pannelRenderer.sharedMaterial.SetTextureOffset("_MainTex", Vector2.one);
    }
}

// 상황에 맞지 않은 컴포넌트 사용
// 정상 로직 아님 // material 탐색하면서 비용발생 // 차라리 transform 비교 
// Best 비교 
// Enum 열거형으로 비교 
