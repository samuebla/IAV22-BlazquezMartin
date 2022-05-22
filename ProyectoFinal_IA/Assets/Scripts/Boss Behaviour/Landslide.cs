using UnityEngine;

public class Landslide : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;

    [SerializeField]
    private GameObject displaySphereCollider;

    private GameObject aoeDisplayGameobject;

    protected override void displayAoe()
    {
        castTime = 5;
        actionTime = 5;

        //We display the area of effect
        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //We show the castbar in the hud
        GameManager.getInstance().startEnemyAbility(castTime, "Landslide");

        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //The boss looks at the player while casting
        GetComponent<LookAtPlayer>().setIsLooking(true);
    }

    protected override void doAction()
    {
        //Play the sound
        GetComponent<AudioSource>().Play();

        //Stops looking at the player
        GetComponent<LookAtPlayer>().setIsLooking(false);

        Destroy(aoeDisplayGameobject);

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        Instantiate<GameObject>(displaySphereCollider);
    }

    protected override void stopAction()
    {
    }
}