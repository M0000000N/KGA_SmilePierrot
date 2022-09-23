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

    private List<int> csvColorIndex;

    private void Awake()
    {
        pannelRenderer = transform.GetChild(0).GetComponent<MeshRenderer>(); ;
        colorText = GetComponentInChildren<TextMeshPro>();
    }
    private void Start()
    {
        csvColorIndex = CSVParser.Instance.GetColorIndex(GameManager.Instance.Stage);

        ResourceMaterial = Resources.LoadAll<Material>("MaterialColor");

        RandomMaterial = new Material[RememberCount];

        SetRandomRememberColor();
        StartCoroutine("SetPannelColorCoroutine");
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

    IEnumerator SetPannelColorCoroutine()
    {
        int index = 0;
        while (index < RememberCount)
        {
            SetPannelColor(index);
            colorText.text = colorTextArray[int.Parse(pannelColor.name) - 1];
            Debug.Log(index + "��° ���� : " + pannelColor);
            yield return new WaitForSeconds(delayTime);
            index++;
        }
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
