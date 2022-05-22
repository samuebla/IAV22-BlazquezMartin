using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHealth : MonoBehaviour
{

    int health_;

    bool invulnerable;

    float invulTime = 1;
    float timeLastHit;
    void Start()
    {
        health_ = 2;
        invulnerable = false;
    }

    void Update()
    {
        if (invulnerable && timeLastHit + invulTime <= Time.time)
        {
            invulnerable = false;
        }
    }

    public void loseHealth()
    {
        health_--;
        timeLastHit = Time.time;
        invulnerable = true;
        if (health_ == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
