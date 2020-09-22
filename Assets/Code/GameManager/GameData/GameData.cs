using UnityEngine;
using System.Collections;

public class GameData
{
    public PlayerStats playerStats;

    public int level;
    public int health;
    public float[] position;



    #region Save to file & Load from file
    public void SaveGameData()
    {
        playerStats.sceneIndex = GetCurrentSceneIndex;
        SaveSystem.SavePlayerData(this);
    }

    public void LoadGameData(int levelIndex = 0)
    {
        if (!SaveSystem.TryLoadPlayerData(this))
        {
            Debug.LogWarning("Saved game data doesn't exist. Player shouldn't have been able to load in the first place.");

            playerStats.sceneIndex = GetCurrentSceneIndex;

            playerStats.level = 1;
            //playerStats.CurrentHealth = 100;
            playerStats.position = new Vector3(0f, 0f, 0f);
        }
    }

    int GetCurrentSceneIndex => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    #endregion

}
/*
     public int gameLevelIndex;
    //PLAYER
    public int playerLevel;
    public int playerHealth;
    public Vector3 playerPosition;

   

 */