using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadWriteFile
{
    public void WriteFile()
    {
        string path = "Assets//Resources//testFile.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Game Development");
        writer.Close();
    }

    public void ReadFile()
    {
        string path = "Assets//Resources//testFile.txt";
        StreamReader read = new StreamReader(path, true);
        Debug.Log(read.ReadToEnd());
        read.Close();
    }
}