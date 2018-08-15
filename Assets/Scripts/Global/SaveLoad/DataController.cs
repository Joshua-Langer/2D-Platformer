using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour {

    GameManager gameManager;
    public LevelData[] allLevelData;

    string gameDataFileName = "data.json";
    
    // Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //LoadGameData();
        //LoadPlayerProgress();
        SceneManager.LoadScene(1);
	}

    void Update()
    {
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }
        Debug.Log(gameManager);
    }
	
    public LevelData GetCurrentLevelData()
    {
        return allLevelData[0];
    }

    //Temp will be time to beat
    public void SubmitHighestLevelCompleted(int level)
    {
        if(level > gameManager.highestLevel)
        {
            gameManager.highestLevel = level;
            SavePlayerProgress();
        }
    }

    //Temp will be getting best time
    public int GetHighLevel()
    {
        return gameManager.highestLevel;
    }

    void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if(File.Exists(filePath))
        {
            //Read the JSON from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtil, and tell it to create a GameData object from it
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            //Retrieve the properties
            allLevelData = loadedData.allLevelData;
        }
        else
        {
            Debug.Log("Can't load game data!");
        }
    }

    void LoadPlayerProgress()
    {
        gameManager = new GameManager();

        if(PlayerPrefs.HasKey("highestLevel"))
        {
            gameManager.highestLevel = PlayerPrefs.GetInt("highestLevel");
        }
    }

	void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestLevel", gameManager.highestLevel);
    }
}
