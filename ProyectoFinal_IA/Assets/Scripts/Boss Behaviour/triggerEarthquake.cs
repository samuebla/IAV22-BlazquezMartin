using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEarthquake : MonoBehaviour
{
    float timeToDestroy = 0.1f;
    float timer = 0;

    bool dontRecieveDmg = true;

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
            //Recibe daño
            dontRecieveDmg = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Si se sale antes de que acabe...
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //No lo recibe
            dontRecieveDmg = true;
        }
    }    
}
