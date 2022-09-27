using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public GameObject[] skulls;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < skulls.Length; i++)
        {
            if(i < int.Parse(CSVParser.Instance.GetCsvData(GameManager.Instance.Stage).Remember_count)) // TODO : csv���� �����ͼ� �ݿ��ؾ� �մϴ�.
            {
                skulls[i].SetActive(true);
            }
            else
            {
                skulls[i].SetActive(false);
            }
        }
    }
}
