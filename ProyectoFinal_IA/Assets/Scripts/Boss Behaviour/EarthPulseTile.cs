using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPulseTile : MonoBehaviour
{
    public enum TileState { NotActive, Casting, Activated, Terminated }

    private TileState currentState = TileState.NotActive;

    private BoxCollider collider;
    private SpriteRenderer renderer;

    private float activationTime;

    private float castTime = 5;
    private float actionTime = 5;


    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider>();
        renderer = gameObject.GetComponent<SpriteRenderer>();

        renderer.enabled = false;
    }

    void Update()
    {
        switch (currentState)
        {
            case TileState.Casting:
                if (activationTime + castTime <= Time.time)
                {
                    currentState = TileState.Activated;

                    renderer.enabled = false;
                    activationTime = Time.time;
                }

                break;

            case TileState.Activated:
                if (activationTime + actionTime <= Time.time)
                {
                    currentState = TileState.Terminated;

                    //Deactivate visual effect

                }

                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentState == TileState.NotActive && other.gameObject.GetComponent<EarthPulseTile>().getCurrentState() == TileState.Activated)
        {
            currentState = TileState.Casting;

            //Start
            activationTime = Time.time;

            renderer.enabled = true;
        }
    }

    public TileState getCurrentState()
    {
        return currentState;
    }

    public void manualActivate()
    {
        if (currentState == TileState.NotActive)
        {
            currentState = TileState.Casting;

            //Start
            activationTime = Time.time;

            renderer.enabled = true;
        }
    }
}
