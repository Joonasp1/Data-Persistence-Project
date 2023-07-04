using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager Instance;

    public int highScore;
    public string highScoreHolder;
    public string playerName;

    private void Awake()
    {
        highScore = 0;
        highScoreHolder = "none";
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreFromFile();
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
        public string name;
    }

    public void SaveScoreToFile()
    {
        SaveData data = new SaveData();

        data.score = highScore;
        data.name = highScoreHolder;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void LoadScoreFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.score;
            highScoreHolder = data.name;


        }

    }
}
