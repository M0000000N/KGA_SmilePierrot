using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pannel : MonoBehaviour
{
    private List<int> colorIndex;
    private void Start()
    {
            Debug.Log("���Գ�");
        colorIndex = CSVParser.Instance.GetColorIndex(1);
        for (int i = 0; i < colorIndex.Count; i++)
        {
            Debug.Log(colorIndex[i]);
        }
    }
}
