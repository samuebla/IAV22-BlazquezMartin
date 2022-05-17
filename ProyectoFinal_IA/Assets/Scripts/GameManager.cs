using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Vida del enemigo
    int enemyLife;

    bool win;

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
    private void Start()
    {
        win = false;
    }

    public void setEnemyLife(int life)
    {
        enemyLife = life;
    }

    public void loseGame() 
    {
        Debug.Log("Perdiste weyu");
    }

    public void winGame()
    {
        Debug.Log("Ganamos Yey");
    }

    public void enemyRecieveDamage(int amount)
    {
        enemyLife -= amount;
        //Lo mostramos en la interfaz
        UIManager.getInstance().updateEnemyHealth(enemyLife);

        //Si has ganado...
        if (enemyLife <= 0)
        {
            win = true;
            winGame();
        }
    }
}
