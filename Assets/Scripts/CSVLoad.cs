using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVLoad : MonoBehaviour
{
    

    public static List<string> LoadData(string fileName)
    {
        //������ Path ����
        string filePath = Application.dataPath + "\\" + fileName;

        TextReader tr = new StreamReader(filePath);
        if (tr == null) return null;

        List<string> dataList = new List<string>();
        string line = tr.ReadLine(); //ù���� Properties�̹Ƿ� ���� ó������
        

        while (line != null)
        {
            line = tr.ReadLine();
            dataList.Add(line);
            if (line == null) break;
        }

        return dataList;
    }

}
