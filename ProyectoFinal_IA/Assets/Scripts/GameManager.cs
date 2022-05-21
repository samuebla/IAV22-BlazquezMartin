using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Vida del enemigo
    int enemyLife = 100;

    const int PLAYERATTACKDMG = 10;

    bool win;

    private UIManager theUIManager;

    private GameObject player;

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

    public void setPlayer(GameObject player_)
    {
        player = player_;
    }

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
    }

    private void Start()
    {
        win = false;
    }

    public int getPlayerDmg()
    {
        return PLAYERATTACKDMG;
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
        player.GetComponent<Animator>().SetBool("Jump", true);
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
    //Y lo mostramos en la interfaz
    theUIManager.GetComponent<UIManager>().disablePlayerProgressBar();
}

/// <summary>
/// El GM controla cuando el jugador pierde vida por culpa del enemigo
/// </summary>
/// <param name="amount"></param>
public void playerLoseLife(int amount)
{
    player.GetComponent<Health>().loseLife(amount);
}

public void updatePlayerHealth(int amount)
{
    theUIManager.GetComponent<UIManager>().updatePlayerHealth(amount);
}

public void buttonResetLevel()
{
    SceneManager.LoadScene("FinalScene");
}

/// <summary>
/// Con este metodo mostramos en la interfaz el casteo de la habilidad del boss
/// </summary>
/// <param name="seconds"></param>
/// <param name="text"></param>
public void startEnemyAbility(float seconds, string text)
{
    theUIManager.GetComponent<UIManager>().enableEnemyProgressBar(seconds, text);
}
}
