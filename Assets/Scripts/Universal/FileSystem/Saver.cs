using System;
using System.IO;
using UnityEngine;

[Serializable]
public class Saver<T>
{
    public T Data;

    private static string Path(string filename)
    {
        return $"{Application.persistentDataPath}/{filename}";
    }

    public static void Save(string filename, T data)
    {
        var wrapper = new Saver<T> { Data = data};
        var dataString = JsonUtility.ToJson(wrapper);

        File.WriteAllText(Path(filename), dataString);
    }

    public static void TryLoad(string filename, ref T data)
    {
        var path = Path(filename);

        if (File.Exists(path))
        {
            var dataString = File.ReadAllText(path);
            var saver = JsonUtility.FromJson<Saver<T>>(dataString);
            data = saver.Data;
        }
    }
}
