using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveWaves(WaveController controller)
    {
        //BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.dataPath + "/Resources/Waves.json";
        //FileStream stream = new FileStream(path, FileMode.Create);

        WaveData data = new WaveData(controller);

        string jsonData = JsonUtility.ToJson(data);
        //formatter.Serialize(stream, data);
        //stream.Close();
        File.WriteAllText(path, jsonData);
    }

    public static WaveData LoadWaves()
    { 
        string path = Application.dataPath + "/Resources/Waves.json";

        if(File.Exists(path))
        {
            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream(path, FileMode.Open);

            var data = File.ReadAllText(path);
            WaveData waveData = JsonUtility.FromJson<WaveData>(data);

            //WaveData data =  formatter.Deserialize(stream) as WaveData;
            //stream.Close();
            return waveData;
        }
        else
        {
            Debug.LogError("Save file not found at " + path);
            return null;
        }
    }

}
