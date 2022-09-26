//using System;
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
        int[] isDone = new int[ResourceMaterial.Length]; // 4�� �÷��� 3�� �̻� �ȳ�������

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
        UIManager.Instance.��.text = "�� : ";
        while (index < RememberCount)
        {
            SetPannelColor(index);
            colorText.text = colorTextArray[int.Parse(pannelColor.name) - 1];
            Debug.Log(index + "��° ���� : " + pannelColor);
            UIManager.Instance.��.text += $"{pannelColor.name} / ";
            yield return new WaitForSeconds(delayTime);
            index++;
        }
        ShowAll = true;
        Debug.Log("�����");
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
