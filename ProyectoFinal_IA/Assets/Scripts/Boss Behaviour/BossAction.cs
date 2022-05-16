using UnityEngine;

public class BossAction : MonoBehaviour
{
    enum ActionState { NotActive, Casting, Activated }

    private ActionState currentState = ActionState.NotActive;
    private float activationTime;

    protected float castTime = 5;
    protected float actionTime = 5;

    /// <summary>
    /// Called from Bolt when the action starts
    /// </summary>
    public void StartAction()
    {
        currentState = ActionState.Casting;
        activationTime = Time.time;
        displayAoe();

        //Update UI

    }

    private void Update()
    {
        switch (currentState)
        {
            case ActionState.Casting:
                if (activationTime + castTime <= Time.time)
                {
                    currentState = ActionState.Activated;
                    activationTime = Time.time;

                    //Do the action
                    doAction();

                    //Update UI

                }
                break;
            case ActionState.Activated:
                if (activationTime + actionTime <= Time.time)
                {
                    //Stop action
                    stopAction();

                    currentState = ActionState.NotActive;
                }
                break;
        }
    }

    protected virtual void displayAoe() { }
    protected virtual void doAction() { }
    protected virtual void stopAction() { }

    public bool actionEnded()
    {
        return currentState == ActionState.NotActive;
    }
}
