using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
    // timer;
    GameObject destroyableObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //timer.TimerStop();
            destroyableObject = new GameObject("Can Be Destroyed");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
