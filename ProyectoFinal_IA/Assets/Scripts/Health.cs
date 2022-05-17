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

    public void loseLife(int amount)
    {
        health -= amount;

        //Lo mostramos en la interfaz
        UIManager.getInstance().updatePlayerHealth(health);

        if (health <= 0)
            GameManager.getInstance().loseGame();
    }
}
