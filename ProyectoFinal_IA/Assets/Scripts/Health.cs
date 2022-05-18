using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health;

    public GameObject crown;
    public GameObject slime;
    void Start()
    {
        health = 5;
    }

    public void loseLife(int amount)
    {
        health -= amount;

        //Lo mostramos en la interfaz
        GameManager.getInstance().updatePlayerHealth(health);

        if (health <= 0)
        {
            //Quitamos el slime
            crown.SetActive(false);
            slime.SetActive(false);

            //Y le quitamos la movilidad
            GetComponent<PlayerController>().enabled = false;

            //Activamos el cursor por si ha muerto con el cursor desaparecido
            Cursor.lockState = CursorLockMode.None;

            //GameManager.getInstance().loseGame();
        }
    }
}
