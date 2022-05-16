using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image playerProgressBar;
    public Image enemyProgressBar;

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
        playerProgressBar.GetComponent<ProgressBar>().setParameters(seconds,"Chanel ganadora");
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
    void Start()
    {
        //TESTING AAA
        enablePlayerProgressBar(5);
        enableEnemyProgressBar(10);
    }

    void Update()
    {
        
    }
}
