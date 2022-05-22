using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEarthquake : MonoBehaviour
{
    float timeToDestroy = 0.1f;
    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player is inside
        if (other.gameObject.GetComponent<PlayerController>())
        {
            GameManager.getInstance().playerLoseLife(1);
        }
    }
}
