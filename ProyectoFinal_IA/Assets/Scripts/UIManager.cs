using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image playerProgressBar;

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
        playerProgressBar.GetComponent<ProgressBar>().setParameters(seconds);
    }
    void Start()
    {
        //TESTING AAA
        enablePlayerProgressBar(5);
    }

    void Update()
    {
        
    }
}
