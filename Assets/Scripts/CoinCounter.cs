using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public ScoreManager scoreManager;

    public TMP_Text yenCoinText;
    public TMP_Text currentYenScoreText;
    public TMP_Text TotalCoinsText;
    
    
    void DisplayText() {
        yenCoinText.text = "Total Yen: " + ScoreManager.beforeThisLevelYenValue;
        currentYenScoreText.text = "Current Yen: " + ScoreManager.thisLevelYenValue + " / " + ScoreManager.totalYenValueInLevel;

        int totalCoinCount = ScoreManager.thisLevelCoinCount + ScoreManager.beforeThisLevelCoinCount;
        TotalCoinsText.text = "Total Coins: " + totalCoinCount + " / " + ScoreManager.TOTAL_COINS_IN_GAME;
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayText();   
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText();
    }
}
