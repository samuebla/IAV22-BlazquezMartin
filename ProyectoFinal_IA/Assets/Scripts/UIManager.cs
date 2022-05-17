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
    private Image enemyProgressBar;
    [SerializeField]
    private Image enemyHealth;

    private int maxEnemyHealth = 100;

    private static UIManager instance;

    public static UIManager getInstance()
    {
        return instance;
    }

    /// <summary>
    /// Activa la barra de progreso del jugador con los segundos que sea
    /// </summary>
    /// <param name="seconds"></param>
    public void enablePlayerProgressBar(float seconds)
    {
        //Lo activamos
        playerProgressBar.gameObject.SetActive(true);
        //Y establecemos los parametros...
        playerProgressBar.GetComponent<ProgressBar>().setParameters(seconds, "Chanel ganadora");
    }

    /// <summary>
    /// Activa la barra de progreso del jugador con los segundos que sea
    /// </summary>
    /// <param name="seconds"></param>
    public void enableEnemyProgressBar(float seconds)
    {
        //Lo activamos
        enemyProgressBar.gameObject.SetActive(true);
        //Y establecemos los parametros...
        enemyProgressBar.GetComponent<ProgressBar>().setParameters(seconds, "Odio a ReinoUnido");
    }

    public void updateEnemyHealth(int amount)
    {
        enemyHealth.fillAmount = (float)amount/(float)maxEnemyHealth;
    }
    public void updatePlayerHealth(int amount)
    {
        for (int i = playerHealth.Length - 1; i >= amount; i--)
            //Desactivamos los corazones
            playerHealth[i].enabled = false;
    }

    void Start()
    {
        //TESTING AAA
        enablePlayerProgressBar(5);
        enableEnemyProgressBar(10);
        updateEnemyHealth(50);
        updatePlayerHealth(3);
    }

    void Update()
    {
    }
}
