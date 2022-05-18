using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Vida del enemigo
    int enemyLife;

    bool win;

    private UIManager theUIManager;


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

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
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
        theUIManager.GetComponent<UIManager>().updateEnemyHealth(enemyLife);

        //Si has ganado...
        if (enemyLife <= 0)
        {
            win = true;
            winGame();
        }
    }

    public void playerAttack(float seconds)
    {
        theUIManager.GetComponent<UIManager>().enablePlayerProgressBar(seconds);
    }

    public void stopPlayerAttack()
    {
        theUIManager.GetComponent<UIManager>().disablePlayerProgressBar();
    }

    public void updatePlayerHealth(int amount)
    {
        theUIManager.GetComponent<UIManager>().updatePlayerHealth(amount);
    }

    public void buttonResetLevel()
    {
        SceneManager.LoadScene("FinalScene");
    }
}
