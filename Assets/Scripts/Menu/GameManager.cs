using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager
{
    public static GameManager Instance { get; private set; } = new GameManager();
    public GameStatistics Statistics = new();
    public int QuestNumber = 1;
    public bool FromLoad = false;
    public int PlayerGold = 0;
    public bool isAyamAlive1 = false;
    public bool isAyamAlive2 = false;
    public bool isAyamAlive3 = false;
    public bool isAyamAlive4 = false;
    public bool isAyamAlive5 = false;
    public Difficulty Difficulty = Difficulty.Easy;
    public int buffDamageTaken = 0;

    private GameManager()
    {
        PersistanceManager.Instance.LoadStatistics();
    }

    public static void NewGame()
    {
        Instance = new GameManager
        {
            Statistics = new GameStatistics(),
            Difficulty = (Difficulty)PlayerPrefs.GetInt(DifficultyOptionSystem.DIFFICULTY_PREFS_KEY, (int)Difficulty.Easy)
        };
        PersistanceManager.Instance.LoadSaveDescriptions();
        SceneManager.LoadScene("Quest-1");
    }


    public static void LoadGame(SaveData saveData)
    {
        Instance = new GameManager
        {
            Statistics = saveData.Statistics,
            QuestNumber = saveData.QuestNumber,
            PlayerGold = saveData.PlayerGold,
            FromLoad = true,
            Difficulty = saveData.Difficulty,
            buffDamageTaken = saveData.BuffDamageTaken,
        };
        SceneManager.LoadScene("Quest-" + Instance.QuestNumber);
    }

    public static void SaveGame(SaveData saveData, SaveDescriptions.Description description, int saveIndex)
    {
        PersistanceManager.Instance.SaveGame(saveData, description, saveIndex);
    }


    public static void NextQuest()
    {
        Instance.QuestNumber++;
        Instance.FromLoad = false;
        SceneManager.LoadScene("Quest-" + Instance.QuestNumber);
    }
}