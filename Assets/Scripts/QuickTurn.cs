using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
    }

    void Turn()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.Rotate(0, 0, 180);
            }
        }
}
