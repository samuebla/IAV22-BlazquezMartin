using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPulseTile : MonoBehaviour
{
    enum TileState { NotActive, Casting, Activated, Terminated }

    private TileState currentState = TileState.NotActive;

    private BoxCollider collider;
    private SpriteRenderer renderer;

    private float activationTime;

    protected float castTime = 5;
    protected float actionTime = 5;


    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider>();
        renderer = gameObject.GetComponent<SpriteRenderer>();

        collider.enabled = false;
        renderer.enabled = false;
    }

    void Update()
    {
        if (currentState != TileState.NotActive && currentState != TileState.Terminated)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentState == TileState.NotActive)
        {
            currentState = TileState.Casting;

            //Start
            activationTime = Time.time;
        }
    }

    public void manualActivate()
    {
        if (currentState == TileState.NotActive)
        {
            currentState = TileState.Casting;

            //Start
            activationTime = Time.time;
        }
    }
}
