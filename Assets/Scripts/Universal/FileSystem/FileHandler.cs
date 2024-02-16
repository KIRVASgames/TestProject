using System.IO;
using UnityEngine;

public static class FileHandler
{
    public static string Path(string filename)
    {
        return $"{Application.persistentDataPath}/{filename}";
    }

    public static void Reset(string filename)
    {
        var path = Path(filename);

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    internal static bool HasFile(string filename)
    {
        return File.Exists(Path(filename));
    }
}
