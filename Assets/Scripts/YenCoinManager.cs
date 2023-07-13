using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YenCoinManager : MonoBehaviour
{
    [SerializeField] private GameObject nextSceneGameObject;
    
    // private ScoreManager scoreManager;
    public int coinValue;
    //private bool hasBeenPickedUp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCoin();
        
    }

    public void RotateCoin()
    {
        transform.Rotate(0f, 200f * Time.deltaTime, 0f, Space.Self);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ScoreManager.oneYenPickUp = true;
            ScoreManager.AddYenValue(coinValue);
            if (ScoreManager.HasYenToFinish(SceneManager.GetActiveScene().name)) {
                nextSceneGameObject.gameObject.SetActive(true);
            }
            Destroy(this.gameObject);
            
        }
    }
}
