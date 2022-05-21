using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private float max = 3;
    public float current = 0.0f;
    public Image mask;
    bool player = false;

    private void OnEnable()
    {
        current = 0.0f;

    }

    void Update()
    {
        //Si no ha llegado al maximo...
        if (current <= max)
        {
            //Vamos sumando al progreso
            current += Time.deltaTime;
            //Y lo mostramos en pantalla
            getCurrentFill();
        }
        //Una vez llegaran al maximo...
        else
        {
            //Si es la barra del jugador...
            if (player)
                //Le quitamos vida al enemigo
                GameManager.getInstance().enemyRecieveDamage(GameManager.getInstance().getPlayerDmg());

            //Desactivamos el objeto
            this.gameObject.SetActive(false);
        }
    }
    void getCurrentFill()
    {
        float fillAmount = current / max;
        mask.fillAmount = fillAmount;
    }

    //Se llama desde el UIManager
    public void setParameters(float seconds,string abilityName, bool isPlayer = false)
    {
        player = isPlayer;

        //Establecemos el maximo
        max = seconds;

        //Y nombramos la habilidad
        GetComponentInChildren<Text>().text = abilityName;
    }

}
