using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Pannel : MonoBehaviour
{
    private Renderer pannelRenderer;
    private Material[] ResourceMaterial; // ���ҽ��������� ������ ��
    private TextMeshPro colorText;
    private string[]colorTextArray = new string[] { "RED", "BLUE", "GREEN", "WHITE"};

    public float delayTime;

    public int RememberCount;

    public Material pannelColor; // ���� �г� �÷�
    public Material[] RandomMaterial; // �������� ����� ��

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
        int[] isdone = new int[ResourceMaterial.Length]; // 4�� �÷��� 3�� �̻� �ȳ�������

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
        UIManager.Instance.InGameUI.AnswerText.text = "�� : ";
        while (index < RememberCount)
        {
            SetPannelColor(index);
            colorText.text = colorTextArray[int.Parse(pannelColor.name) - 1];
            UIManager.Instance.InGameUI.AnswerText.text += pannelColor.name + " / ";
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
        pannelColor = RandomMaterial[_index];
        pannelRenderer.sharedMaterial = pannelColor;
        pannelRenderer.sharedMaterial.SetTextureOffset("_MainTex", Vector2.one);
    }
}

// ��Ȳ�� ���� ���� ������Ʈ ���
// ���� ���� �ƴ� // material Ž���ϸ鼭 ���߻� // ���� transform �� 
// Best �� 
// Enum ���������� �� 
