using UnityEngine;

public class Earthquake : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;

    [SerializeField]
    private GameObject displaySphereCollider;

    private GameObject aoeDisplayGameobject;

    protected override void displayAoe()
    {
        castTime = 4;
        actionTime = 4;
        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //We show the castbar in the hud
        GameManager.getInstance().startEnemyAbility(castTime, "Earthquake");

        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //Looks to the player while casting
        GetComponent<LookAtPlayer>().setIsLooking(true);
    }

    protected override void doAction()
    {
        //Stops looking at player
        GetComponent<LookAtPlayer>().setIsLooking(false);

        //Trigger that deals damage to the player
        Instantiate<GameObject>(displaySphereCollider);

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        Destroy(aoeDisplayGameobject);
    }

    protected override void stopAction()
    {

    }
}