using Firebase.Database;
using UnityEngine;

public class SaveManager : MonoSingleton<SaveManager>
{
    public override void Init()
    {
        
    }

    public void SaveData<T>(T data) where T : new()
    {
        if (data != null)
        {
            string json = JsonUtility.ToJson(data);
            string key = data.GetType().Name;
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();

            Debug.Log(key + " : " + json);
        }
    }

    public T LoadData<T>() where T : new()
    {
        T loadData = new ();
        string key = loadData.GetType().Name; 

        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            loadData = JsonUtility.FromJson<T>(json);
            Debug.Log(key + " : " + json);
        }
        else
        {
            SaveData(loadData);
        }
        return loadData;
    }
}
