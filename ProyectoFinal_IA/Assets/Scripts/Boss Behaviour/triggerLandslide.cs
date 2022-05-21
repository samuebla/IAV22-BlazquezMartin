using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerLandslide : MonoBehaviour
{
    float timeToDestroy = 3;
    float timer = 0;

    bool dontRecieveDmg = false;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy)
        {
            //Si no se ha posicionado correctamente
            if (!dontRecieveDmg)
                //Pierde una vida
                GameManager.getInstance().playerLoseLife(1);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador esta dentro...
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //No recibe daño
            dontRecieveDmg = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Si se sale antes de que acabe...
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Vuelve a recibir daño
            dontRecieveDmg = false;
        }
    }    
}
