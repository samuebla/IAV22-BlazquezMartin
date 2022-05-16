using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        //Si se ha chocado con el player...
        if (collision.gameObject.GetComponent<PlayerController>())
            collision.gameObject.GetComponent<Health>().loseLife(10);
    }
}
