using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pannel : MonoBehaviour
{
    private Renderer pannelRenderer;

    public int Index;

    public int RememberCount;

    public Material pannelColor; // 현재 패널 컬러
    public Material[] ResourceMaterial; // 리소스폴더에서 가져올 색
    public Material[] RandomMaterial; // 랜덤으로 저장될 색

    private List<int> colorIndex;

    private void Awake()
    {
        pannelRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        colorIndex = CSVParser.Instance.GetColorIndex(1); //stage1 : 1, 3, 5, stage2 : 1, 2, 4, 5

        ResourceMaterial = Resources.LoadAll<Material>("MaterialColor");
        RandomMaterial = new Material[RememberCount];

        SetRandomRememberColor();
        //SetPannelColor(Index);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Index++;
            SetPannelColor(Index);
        }
    }

    public void SetRandomRememberColor()
    {
        for (int i = 0; i < RememberCount; i++)
        {
            int randNum = colorIndex[Random.Range(0, colorIndex.Count)];
            RandomMaterial[i] = ResourceMaterial[randNum-1];
        }
    }

    public void SetPannelColor(int _index)
    {
        pannelColor = RandomMaterial[_index-1];
        pannelRenderer.sharedMaterial = pannelColor;
        pannelRenderer.sharedMaterial.SetTextureOffset("_MainTex", Vector2.one);
    }
}
