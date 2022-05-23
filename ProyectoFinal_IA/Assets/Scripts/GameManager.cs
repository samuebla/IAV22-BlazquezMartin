using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int enemyLife = 100;

    const int PLAYERATTACKDMG = 10;

    private UIManager theUIManager;

    private GameObject player;
    private GameObject enemy;

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
    public void setEnemy(GameObject enemy_)
    {
        enemy = enemy_;
    }
    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
    }

    public void enemyRecieveDamage(int amount)
    {
        player.GetComponent<Animator>().SetBool("Jump", true);
        enemyLife -= amount;
        
        theUIManager.GetComponent<UIManager>().updateEnemyHealth(enemyLife);

        //If he died...
        if (enemyLife <= 0)
        {
            //Set the die animation
            Animator anim = enemy.GetComponent<Animator>();
            anim.SetBool("idle", false);
            anim.SetBool("walk", false);
            anim.SetBool("jump", false);
            anim.SetBool("defy", false);
            anim.SetBool("die", true);

            //Disable all attacks
            enemy.GetComponent<Earthquake>().enabled = false;
            enemy.GetComponent<Landslide>().enabled = false;
            enemy.GetComponent<Roar>().enabled = false;
            enemy.GetComponent<Rockbuster>().enabled = false;
            enemy.GetComponent<EarthPulse>().enabled = false;
            enemy.GetComponent<EarthExpulsion>().enabled = false;
            enemy.GetComponent<TitanicSlam>().enabled = false;
            enemy.GetComponent<TitanicRoar>().enabled = false;
            enemy.GetComponent<LookAtPlayer>().enabled = false;
            
            //Disable the progress bar
            theUIManager.GetComponent<UIManager>().disableEnemyProgressBar();

            //Block Input
            player.GetComponent<PlayerController>().blockInput();
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

    public void ExitButton()
    {
        Application.Quit();
    }
    /// <summary>
    /// GM controls when the player loses life
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
    /// Enable the enemy progress bar
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="text"></param>
    public void startEnemyAbility(float seconds, string text)
    {
        theUIManager.GetComponent<UIManager>().enableEnemyProgressBar(seconds, text);
    }

    public int getPlayerDmg()
    {
        return PLAYERATTACKDMG;
    }

    public void loseGame()
    {
        enemy.GetComponent<WinOrLose>().startWinOrLose(false);
    }

    public void winGame()
    {
        enemy.GetComponent<WinOrLose>().startWinOrLose(true);
    }
}
