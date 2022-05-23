using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPulseTile : MonoBehaviour
{
    public enum TileState { NotActive, Casting, Activated, Terminated }

    private TileState currentState = TileState.NotActive;

    private BoxCollider collider;
    private SpriteRenderer renderer;

    [SerializeField]
    private GameObject cubeCollider;

    [SerializeField]
    private GameObject damageIndicatorPrefab;

    private GameObject damageIndicator;

    private float activationTime;

    private float castTime = 2;
    private float actionTime = 0.5f;

    private float timeBeforeNextActivation = 5;
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

                    Instantiate<GameObject>(cubeCollider,this.transform.position, Quaternion.identity);
                    damageIndicator = Instantiate<GameObject>(damageIndicatorPrefab,this.transform.position, Quaternion.identity);
                    damageIndicator.transform.Rotate(-90, 0, 45);
                    //damageIndicator.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }

                break;

            case TileState.Activated:
                if (activationTime + actionTime <= Time.time)
                {
                    currentState = TileState.Terminated;

                    activationTime = Time.time;

                    //Deactivate visual effect
                    Destroy(damageIndicator);
                }

                break;

            case TileState.Terminated:
                if (activationTime + timeBeforeNextActivation <= Time.time)
                {
                    currentState = TileState.NotActive;
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
