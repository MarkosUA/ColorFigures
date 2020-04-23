using UnityEngine;
using System.IO;

public class PrefabNamesLoader : MonoBehaviour
{
    private const string FILE_NAME = "Save.json";

    public static T LoadNames<T>()
    {
        var path = Path.Combine(Application.dataPath, FILE_NAME);

        if (File.Exists(path))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }
        else
            return default(T);
    }

    public static void SaveNames(object obj)
    {
        var path = Path.Combine(Application.dataPath, FILE_NAME);

        File.WriteAllText(path, JsonUtility.ToJson(obj));
    }
}