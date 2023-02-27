using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVLoad : MonoBehaviour
{
    

    public static void LoadData(string fileName)
    {
        //저장할 Path 설정
        string filePath = Application.dataPath + "\\" + fileName;

        TextReader tr = new StreamReader(filePath);
        if (tr == null) return;

        List<ObjectData> dataLis = new List<ObjectData>();

        string line = tr.ReadLine();//첫줄은 Properties이므로 따로 처리안함
        string[] tok;

        while (line != null)
        {
            line = tr.ReadLine();
            if (line == null) break;

            tok = line.Split(",");
        }

        tr.Close();

        return;
    }

}
