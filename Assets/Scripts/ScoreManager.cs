using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{    
    [SerializeField] public Timer timer;
    [SerializeField] Scene scene;
    [SerializeField] public static int beforeThisLevelYenValue = 0; // yen VALUE collected before this level (will be kept!)
    [SerializeField] public static int thisLevelYenValue = 0; // yen VALUE collected in this level


    [SerializeField] public static int thisLevelCoinCount = 0; // NUMBER of coins collected in this level
    [SerializeField] public static int beforeThisLevelCoinCount = 0; // NUMBER of coins collected before this level (will be kept!)
    
    [SerializeField] public static int TOTAL_COINS_IN_GAME = 20;



    [SerializeField] public static int hasEnoughValueToFinish; // total yen value required to spawn the next level portal
    [SerializeField] public static int totalYenValueInLevel; // total yen value up to and including this level


    [SerializeField] private AudioSource backgroundMusic;



    public static Dictionary<string, int> levelCoinValues = new Dictionary<string, int>(){
        {"Level 1", 1},
        {"Level 2", 4},
        {"Level 3", 30},
        {"Level 4", 60},
        //{"Level 5", 100},
        //{"Level 6", 500},
    };


    //public static int score;

    void Awake()
    {
        
        DontDestroyOnLoad(this);
        scene = SceneManager.GetActiveScene();
        
    }

    void Start()
    {
        backgroundMusic.Play();
        timer.TimerStart();
        
    }

    void DestroyOnMainMenu()
    {
        if (scene.name == "MainMenu")
        {
            //Destroy(instance.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOnMainMenu();
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level 1":
                // Debug.Log(levelCoinValues[SceneManager.GetActiveScene().name]);
                totalYenValueInLevel = 1; //has enough to finish = 1
                hasEnoughValueToFinish = 1;
            break;
            case "Level 2":
                totalYenValueInLevel = 9; //has enough to finish = 4
                hasEnoughValueToFinish = 4;
            break;
            case "Level 3":
                totalYenValueInLevel = 40; //has enough to finish = 30
                hasEnoughValueToFinish = 30;
            break;
            case "Level 4":
                totalYenValueInLevel = 110; //has enough to finish = 60
                hasEnoughValueToFinish = 60;
            break;
            // case "Level 5":
            //     totalYenValueInLevel = 1;
            // break;
            // case "Level 6":
            //     totalYenValueInLevel = 1;
            // break;
            case "MainEnding":
                totalYenValueInLevel = 1;
            break;
            case "SecretEnding":
                totalYenValueInLevel = 1;
            break;

        }
    }

    public static void AddYenValue(int coinValue)
    {
        thisLevelYenValue += coinValue; //adds coin value to current yen
        thisLevelCoinCount += 1;
    }

    public static void ResetCurrentScores()
    {
        thisLevelYenValue = 0;
        thisLevelCoinCount = 0;
    }

    public static void FinalizeLevelScore()
    {
        beforeThisLevelYenValue += thisLevelYenValue;
        beforeThisLevelCoinCount += thisLevelCoinCount;
        ResetCurrentScores();
    }

    public static bool HasYenToFinish(string sceneName)
    {
        return thisLevelYenValue >= hasEnoughValueToFinish;
    }

    public static int GetTotalCoinCount()
    {
        return thisLevelCoinCount + beforeThisLevelCoinCount;
    }

    public static bool HasYenToSecretEndingFinish(string sceneName)
    {   
        if (GetTotalCoinCount() > TOTAL_COINS_IN_GAME) {
            throw new System.Exception("There shouldn't be more coins collected than total in the game!");
        }
        return GetTotalCoinCount() == TOTAL_COINS_IN_GAME;
    }

    // depricated code // 

    //  public static bool oneYenPickUp;
    //  public static bool fiveYenPickUp;
    //  public static bool tenYenPickUp;
    //  public static bool fiftyYenPickUp;
    // public static bool isLevelOneFinished;
    // public static bool isLevelTwoFinished;
    // public static bool isLevelThreeFinished;
    // public static bool isLevelFourFinished;
    // public static bool isLevelFiveFinished;
    // public static bool isLevelSixFinished;

    // public void YenScore()
    // {
    //     if (oneYenPickUp)
    //     {
    //         yenScore = yenScore + 1;
    //         oneYenPickUp = false;
    //     }

    //     if (fiveYenPickUp)
    //     {
    //         yenScore = yenScore + 5;
    //         fiveYenPickUp = false;
    //     }

    //     if (tenYenPickUp)
    //     {
    //         yenScore = yenScore + 10;
    //         tenYenPickUp = false;
    //     }

    //     if (fiftyYenPickUp)
    //     {
    //         yenScore = yenScore + 50;
    //         tenYenPickUp = false;
    //     }
    // }




    // public void LoadLevelTwo()
    // {
    //     if (isLevelOneFinished)
    //     {
    //         SceneManager.LoadScene("Level 2");
    //     }
    // }

    // public void LoadLevelThree()
    // {
    //     if (isLevelTwoFinished)
    //     {
    //         SceneManager.LoadScene("Level 3");
    //     }
    // }

    // public void LoadLevelFour()
    // {
    //     if (isLevelThreeFinished)
    //     {
    //         SceneManager.LoadScene("Level 4");
    //     }
    // }

    // public void LoadLevelFive()
    // {
    //     if (isLevelFourFinished)
    //     {
    //         SceneManager.LoadScene("Level 5");
    //     }
    // }

    // public void LoadLevelSix()
    // {
    //     if (isLevelFiveFinished)
    //     {
    //         SceneManager.LoadScene("Level 6");
    //     }
    // }

    // public void LoadMainEnding()
    // {
    //     if (isLevelSixFinished)
    //     {
    //         SceneManager.LoadScene("MainEnding");
    //     }
    // }

    // public void LoadSecretEnding()
    // {
    //     if (isLevelSixFinished)
    //     {
    //         //SceneManager.LoadScene("SecretEnding");
    //     }
    // }




}
