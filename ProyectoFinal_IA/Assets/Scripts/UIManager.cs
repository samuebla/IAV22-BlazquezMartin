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
        //Para qie el GameManager tenga una referencia del UIManager
        //y pueda solicitar actualizaciones de la UI
        GameManager.getInstance().SetUIManager(this);

        for (int i = 0; i >= playerHealth.Length - 1; i--)
            //Activamos todos los corazones
            playerHealth[i].enabled = true;

        //Desactivamos todo antes de empezar
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
        //Lo activamos
        playerProgressBar.gameObject.SetActive(true);
        //Y establecemos los parametros...
        playerProgressBar.GetComponent<ProgressBar>().setParameters(seconds, "Chanel ganadora");

        //Si activamos  la habilidad tenemos que desactivar el texto de cancel
        if (startCancel)
        {
            cancelAbility.enabled = false;
            startCancel = false;
            timerCancelImage = 0;
        }
    }
    public void disablePlayerProgressBar()
    {
        //Desactivamos la accion
        playerProgressBar.gameObject.SetActive(false);

        cancelAbility.enabled = true;
        startCancel = true;
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
        enemyHealth.fillAmount = (float)amount / (float)maxEnemyHealth;
    }
    public void updatePlayerHealth(int amount)
    {
        for (int i = playerHealth.Length - 1; i >= amount; i--)
            //Desactivamos los corazones
            playerHealth[i].enabled = false;
    }
}
