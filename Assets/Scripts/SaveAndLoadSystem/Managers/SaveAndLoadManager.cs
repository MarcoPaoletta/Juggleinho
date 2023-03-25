using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoadManager
{
    public static string bestTimeDataPath = Application.persistentDataPath + "/BestTimeData.txt";

    public static BinaryFormatter formatter = new BinaryFormatter();

    public static void SaveBestTimeData(BestTimeSetter currentTimeSetter)
    {
        BestTimeData bestTimeData = new BestTimeData(currentTimeSetter);
        FileStream stream = new FileStream(bestTimeDataPath, FileMode.Create);
        formatter.Serialize(stream, bestTimeData);
        stream.Close();
    }

    public static BestTimeData LoadBestTimeData()
    {
        if(File.Exists(bestTimeDataPath))
        {
            FileStream stream = new FileStream(bestTimeDataPath, FileMode.Open);
            BestTimeData bestTimeData = formatter.Deserialize(stream) as BestTimeData;
            stream.Close();
            return bestTimeData;
        }
        else
        {
            Debug.Log("Best time load file wasn't found");
            return null;
        }
    }
}