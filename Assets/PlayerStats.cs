using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats pStats;

    void Awake()
    {

        if (pStats != null && pStats != this)
        {

            Destroy(pStats);

        }
        else {

            pStats = this;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Check()
    {

        Debug.Log("Test");

    }
}
