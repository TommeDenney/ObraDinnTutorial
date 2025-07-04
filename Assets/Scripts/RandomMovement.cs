using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //important
using UnityEngine.SceneManagement;

//if you use this code you are contractually obligated to like the YT video
public class RandomMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    [SerializeField] public GameObject playerCharacter;
    [SerializeField] private AudioSource terrorSound;
    [SerializeField] private AudioSource heartBeat;
    public NavMeshAgent agent;
    public float distanceFromPlayer;
    [SerializeField] public float killRange = 15f;
    public float range; //radius of sphere
    [SerializeField] public float volumeRange = 0f;

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.angularSpeed = 500;
        agent.acceleration = 100f;
        agent.stoppingDistance = 0f;
        terrorSound.volume = 0.01f;
        heartBeat.volume = 0.01f;
        terrorSound.Play();
        heartBeat.Play();

        
        
    }


    void Update()
    {
        distanceFromPlayer = (gameObject.transform.position - playerCharacter.transform.position).magnitude;

        ChasePlayer();
        VolumeAdjustment();
        

    }
    void VolumeAdjustment()
    {

        // for (volumeRange = 0.001f; distanceFromPlayer <= killRange; volumeRange++)
        // {
        //     if (volumeRange == 1f)
        //     {
        //         break;
        //     }
        // }

        // for (volumeRange = 1f; distanceFromPlayer >= killRange; volumeRange--)
        // {
        //     if (volumeRange == 0f)
        //     {
        //         break;
        //     }
        // }

        if (volumeRange <= 1f && distanceFromPlayer <= killRange)
        {
            volumeRange += (volumeRange + 0.3f) * Time.deltaTime;
        }

        if (volumeRange >= 0f && distanceFromPlayer >= killRange)
        {
            volumeRange -= (volumeRange - 0.3f) * Time.deltaTime;
        }

        if (volumeRange >= 1f)
        {
            volumeRange = 1f;
        }
        else if (volumeRange <= 0.3f)
        {
            volumeRange = 0.3f; 
        }

        terrorSound.volume = volumeRange;
        heartBeat.volume = volumeRange;
        
    }
    void ChasePlayer()
    {
        if (distanceFromPlayer <= killRange)
        {
            agent.speed = 9f;
            agent.destination = playerCharacter.transform.position;
            //terrorSound.volume = volumeRange;
            
            
        }
        else
        {
            agent.speed = 6f;
            //terrorSound.volume = 0f;
            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ScoreManager.ResetCurrentScores();

        }
    }


}