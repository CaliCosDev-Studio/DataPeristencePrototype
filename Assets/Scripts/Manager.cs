using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    public string username;
    public int bestScore;
}

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public string username = null;
    public string bestUsername = null;
    public int bestScore;

    private void Awake() 
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        LoadData();

        if (bestUsername.Length > 1)
        {
            GameObject.Find("Menu Manager").GetComponent<Menu>().ShowBestPlayer(bestUsername, bestScore);
        }
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            bestUsername = data.username;
            bestScore = data.bestScore;
        }
    }

    public void SaveData()
    {
        PlayerData pd = new PlayerData();
        pd.username = username;
        pd.bestScore = bestScore;

        string json = JsonUtility.ToJson(pd);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void DeleteSaveFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
            File.Delete(path);

        bestUsername = null;
        bestScore = 0;

        #if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
		#endif
    }
}
