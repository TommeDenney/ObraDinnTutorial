using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private AudioSource portalSoundFX;
    public string nextSceneName;
    public string secretSceneName = "SecretEnding";

    // Start is called before the first frame update
    void Start()
    {
        portalSoundFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(200f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            ScoreManager.FinalizeLevelScore();
            SceneManager.LoadScene(nextSceneName);
           
        }


    }
}
