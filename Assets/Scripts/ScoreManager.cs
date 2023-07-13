using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int yenScore = 0;
    public static int suicaScore = 0;

    public static int currentYenScore = 0;
    public static int currentSuicaScore = 0;

     public static bool oneYenPickUp;
     public static bool fiveYenPickUp;
     public static bool tenYenPickUp;
     public static bool fiftyYenPickUp;
     public static bool suicaCardPickUp; //suica pickup
    public static bool isLevelOneFinished;
    public static bool isLevelTwoFinished;
    public static bool isLevelThreeFinished;
    public static bool isLevelFourFinished;
    public static bool isLevelFiveFinished;
    public static bool isLevelSixFinished;
    
    private static Dictionary<string, int> levelCoinValues = new Dictionary<string, int>(){
        {"Level 1", 1},
        {"Level 2", 5},
        {"Level 3", 10},
        {"Level 4", 50},
    };


    public static int score;
	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}

    // Update is called once per frame
    void Update()
    {
    }

    public static void AddYenValue(int coinValue) {
        currentYenScore += coinValue;
    }

    public static void AddSuicaValue(int suicaValue) {
        currentSuicaScore += suicaValue;
    }

    public static void ResetCurrentScores() {
        currentYenScore = 0;
        currentSuicaScore = 0;
    }

    public static void FinalizeLevelScore() {
        yenScore += currentYenScore;
        suicaScore += currentSuicaScore;
        ResetCurrentScores();
        
    }

    public static bool HasYenToFinish(string sceneName) {
        return levelCoinValues[sceneName] == currentYenScore;
    }

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
    public void SuicaScore()
    {
        if (suicaCardPickUp)
        {
            suicaScore = suicaScore + 1;
            suicaCardPickUp = false;
        }
    }



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
