using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using System.Linq;


public class DataTable // 실제 데이터와 이름이 같아야한다.
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
        // 1. 리소스 폴더에서 csv 로드
        TextAsset csvTextAsset = Resources.Load<TextAsset>("CSV/"+csv);

        // 2. csv파일 설정 - CsvReader의 매개변수 Configuration에 들어갈 변수
        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|", // 컬럼설정
            NewLine = Environment.NewLine // 개행문자 설정
        };

        // 이곳이 병목지점이 될 수 있음을 주의
        using (StringReader cswString = new StringReader(csvTextAsset.text)) // 파싱한 csv를 읽어온다.
        {
            using (CsvReader csv = new CsvReader(cswString, config))
            {
                IEnumerable<DataTable> records = csv.GetRecords<DataTable>();
                foreach (DataTable record in records)
                {
                    if (false == dataTable.ContainsKey(record.ID))
                    {
                        dataTable[record.ID] = record;

                        // HACK : index는 1부터 시작하기에 0번 요소를 빈 값으로 채움
                        // dataTable[record.Index] = null;
                    }
                    dataTable[record.ID] = record;
                }
            }
        }
    }

    public DataTable GetCsvData(int _index) // 인덱스로 원하는 데이터를 찾는다.
    {
        return dataTable[_index];
    }

    /// <summary>
    /// 해당 스테이지에서 원하는 컬러 인덱스 리스트
    /// </summary>
    /// <param name="_index">스테이지</param>
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