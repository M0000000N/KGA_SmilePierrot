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
    public string color_1 { get; set; }
    public string color_2 { get; set; }
    public string color_3 { get; set; }
    public string color_4 { get; set; }
    public string color_5 { get; set; }
    public string color_6 { get; set; }
    public string color_7 { get; set; }
    public string color_8 { get; set; }
}
public class CSVParser : SingletonBehaviour<CSVParser>
{
    private Dictionary<int, DataTable> dataTable = new Dictionary<int, DataTable>();
    private void Awake()
    {
        // 1. ���ҽ� �������� csv �ε�
        TextAsset csvTextAsset = Resources.Load<TextAsset>("CSV/stage_DB_ver1.1");

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

    private DataTable GetCsvData(int _index) // �ε����� ���ϴ� �����͸� ã�´�.
    {
        return dataTable[_index];
    }

    public List<int> GetColorIndex(int _index)
    {
        List<int> colorIndexList = new List<int>();

        if (GetCsvData(_index).color_1 == "1")
        {
            colorIndexList.Add(1);
        }
        if (GetCsvData(_index).color_2 == "1")
        {
            colorIndexList.Add(2);
        }
        if (GetCsvData(_index).color_3 == "1")
        {
            colorIndexList.Add(3);
        }
        if (GetCsvData(_index).color_4 == "1")
        {
            colorIndexList.Add(4);
        }
        if (GetCsvData(_index).color_5 == "1")
        {
            colorIndexList.Add(5);
        }
        if (GetCsvData(_index).color_6 == "1")
        {
            colorIndexList.Add(6);
        }
        if (GetCsvData(_index).color_7 == "1")
        {
            colorIndexList.Add(7);
        }
        if (GetCsvData(_index).color_8 == "1")
        {
            colorIndexList.Add(8);
        }
        return colorIndexList;
    }
}