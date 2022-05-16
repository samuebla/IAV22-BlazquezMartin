using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    void Awake()
    {
        if (instance == null)
            instance = new GameManager();
        else
            Destroy(this);
    }

    public static GameManager getInstance()
    {
        return instance;
    }

    public void loseGame() 
    {
        Debug.Log("Perdiste weyu");
    }
}
