using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelData
{
    public bool Unlocked;
    public int ScoreToAchieve;
    public int TopScore;
}
[System.Serializable]

public class listofLevel
{
    public List<LevelData> _LevelDatas;
}
public class Session : Singletion<Session>
{
    public listofLevel LevelStatus;
    public int CurrentLevel;
        public int EndlessScore;

    public GameType _GameType;
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Level"), LevelStatus);
        }

        EndlessScore = PlayerPrefs.GetInt("Endless", 000);
    }

    private void OnDisable()
    {
        string key = JsonUtility.ToJson(LevelStatus);
        PlayerPrefs.SetString("Level",key);
        PlayerPrefs.SetInt("Endless",EndlessScore);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            string key = JsonUtility.ToJson(LevelStatus);
            PlayerPrefs.SetString("Level",key);
            PlayerPrefs.SetInt("Endless",EndlessScore);

        }
    }
}
