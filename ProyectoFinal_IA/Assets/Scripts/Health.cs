using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;
    void Start()
    {
        health = 5;
    }

    void loseLife(int amount)
    {
        health -= amount;

        if (health <= 0)
            GameManager.getInstance().loseGame();
    }
}
