using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public string PlayerName;
    public string BestPlayer;
    public int BestScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerName();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string BestPlayer;
        public int BestScore;
    }

    public void SavePlayerName()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.BestPlayer = BestPlayer;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            BestPlayer = data.BestPlayer;
            BestScore = data.BestScore;
        }
    }
}
