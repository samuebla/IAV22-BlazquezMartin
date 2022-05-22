using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    bool isLooking = false;

    private void Start()
    {
        GameManager.getInstance().setEnemy(this.gameObject);
    }
    void Update()
    {
        if (isLooking)
        {
            transform.LookAt(player);
        }
    }

    public void setIsLooking(bool isLooking_) { isLooking = isLooking_; }

    public Vector3 getPlayerPosition()
    {
        return player.position;
    }
}
