using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedInitializationTool : MonoBehaviour
{
    int currentTime = 0;
    void Start()
    {
        currentTime = System.DateTime.Now.Second;
    }

    public int getCurrentRealSecond()
    {
        return currentTime;
    }
}
