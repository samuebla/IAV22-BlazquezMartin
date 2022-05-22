using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerLandslide : MonoBehaviour
{
    float timeToDestroy = 0.1f;
    float timer = 0;

    bool dontRecieveDmg = false;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy)
        {
            if (!dontRecieveDmg)
                GameManager.getInstance().playerLoseLife(1);

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player is inside
        if (other.gameObject.GetComponent<PlayerController>())
        {
            dontRecieveDmg = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //If the player steps out too soon
        if (other.gameObject.GetComponent<PlayerController>())
        {
            //Takes damage
            dontRecieveDmg = false;
        }
    }    
}
