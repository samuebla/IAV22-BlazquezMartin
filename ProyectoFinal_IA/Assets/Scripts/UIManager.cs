using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image playerProgressBar;
    [SerializeField]
    private Image[] playerHealth;
    [SerializeField]
    private Text cancelAbility;

    float timerCancelImage;
    bool startCancel;

    [SerializeField]
    private Image enemyProgressBar;
    [SerializeField]
    private Image enemyHealth;

    private int maxEnemyHealth = 100;


    void Start()
    {
        //Reference for the GameManager
        GameManager.getInstance().SetUIManager(this);

        for (int i = 0; i >= playerHealth.Length - 1; i--)
            playerHealth[i].enabled = true;

        //ALL Disable before starting
        cancelAbility.enabled = false;
        playerProgressBar.gameObject.SetActive(false);
        enemyProgressBar.gameObject.SetActive(false);


        timerCancelImage = 0;
        startCancel = false;
    }

    void Update()
    {
        if (startCancel)
        {
            timerCancelImage += Time.deltaTime;
            if (timerCancelImage >= 2)
            {
                cancelAbility.enabled = false;
                startCancel = false;
                timerCancelImage = 0;
            }
        }
    }

    /// <summary>
    /// Activa la barra de progreso del jugador con los segundos que sea
    /// </summary>
    /// <param name="seconds"></param>
    public void enablePlayerProgressBar(float seconds)
    {
        playerProgressBar.gameObject.SetActive(true);
        //Set the parameters
        playerProgressBar.GetComponent<ProgressBar>().setParameters(seconds, "Attack",true);

        //If we attack, we have to disable the cancelText
        if (startCancel)
        {
            cancelAbility.enabled = false;
            startCancel = false;
            timerCancelImage = 0;
        }
    }
    public void disablePlayerProgressBar()
    {
        if (playerProgressBar.gameObject.active)
        {

        //Disable action
        playerProgressBar.gameObject.SetActive(false);

        cancelAbility.enabled = true;
        startCancel = true;
        }
    }





    /// <summary>
    /// Activa la barra de progreso del jugador con los segundos que sea
    /// </summary>
    /// <param name="seconds"></param>
    public void enableEnemyProgressBar(float seconds, string text)
    {
        //Disable
        enemyProgressBar.gameObject.SetActive(true);
        //Set the parameters
        enemyProgressBar.GetComponent<ProgressBar>().setParameters(seconds, text);
    }

    public void disableEnemyProgressBar()
    {
        //Disable
        enemyProgressBar.gameObject.SetActive(false);
    }
    public void updateEnemyHealth(int amount)
    {
        enemyHealth.fillAmount = (float)amount / (float)maxEnemyHealth;
    }
    public void updatePlayerHealth(int amount)
    {
        if (amount < 0)
            amount = 0;

        for (int i = playerHealth.Length - 1; i >= amount; i--)
            //Disable hearts
            playerHealth[i].enabled = false;
    }
}
