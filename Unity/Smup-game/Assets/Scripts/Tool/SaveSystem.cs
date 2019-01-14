using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveWaves(WaveController controller)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Waves.shmup";
        FileStream stream = new FileStream(path, FileMode.Create);

        WaveData data = new WaveData(controller);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static WaveData LoadWaves()
    {
        string path = Application.persistentDataPath + "/Waves.shmup";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            WaveData data =  formatter.Deserialize(stream) as WaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found at " + path);
            return null;
        }
    }

}
