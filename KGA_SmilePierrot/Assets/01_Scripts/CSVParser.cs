using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using System.Linq;


public class DataTable // ���� �����Ϳ� �̸��� ���ƾ��Ѵ�.
{
    public int ID { get; set; }
    public string Stage { get; set; }
    public string Remember_count { get; set; }
}
public class CSVParser : SingletonBehaviour<CSVParser>
{
    private Dictionary<int, DataTable> dataTable = new Dictionary<int, DataTable>();

    [SerializeField] string csv;

    private void Awake()
    {
        // 1. ���ҽ� �������� csv �ε�
        TextAsset csvTextAsset = Resources.Load<TextAsset>("CSV/"+csv);

        // 2. csv���� ���� - CsvReader�� �Ű����� Configuration�� �� ����
        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|", // �÷�����
            NewLine = Environment.NewLine // ���๮�� ����
        };

        // �̰��� ���������� �� �� ������ ����
        using (StringReader cswString = new StringReader(csvTextAsset.text)) // �Ľ��� csv�� �о�´�.
        {
            using (CsvReader csv = new CsvReader(cswString, config))
            {
                IEnumerable<DataTable> records = csv.GetRecords<DataTable>();
                foreach (DataTable record in records)
                {
                    if (false == dataTable.ContainsKey(record.ID))
                    {
                        dataTable[record.ID] = record;

                        // HACK : index�� 1���� �����ϱ⿡ 0�� ��Ҹ� �� ������ ä��
                        // dataTable[record.Index] = null;
                    }
                    dataTable[record.ID] = record;
                }
            }
        }
    }

    public DataTable GetCsvData(int _index) // �ε����� ���ϴ� �����͸� ã�´�.
    {
        return dataTable[_index];
    }

    /// <summary>
    /// �ش� ������������ ���ϴ� �÷� �ε��� ����Ʈ
    /// </summary>
    /// <param name="_index">��������</param>
    /// <returns></returns>
    //public List<int> GetColorIndex(int _index)
    //{
    //    List<int> colorIndexList = new List<int>();

    //    if (GetCsvData(_index).color_1 == "1")
    //    {
    //        colorIndexList.Add(1);
    //    }
    //    if (GetCsvData(_index).color_2 == "1")
    //    {
    //        colorIndexList.Add(2);
    //    }
    //    if (GetCsvData(_index).color_3 == "1")
    //    {
    //        colorIndexList.Add(3);
    //    }
    //    if (GetCsvData(_index).color_4 == "1")
    //    {
    //        colorIndexList.Add(4);
    //    }
    //    return colorIndexList;
    //}
}