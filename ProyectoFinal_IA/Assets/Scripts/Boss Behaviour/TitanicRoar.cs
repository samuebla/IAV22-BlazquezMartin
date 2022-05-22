using UnityEngine;

public class TitanicRoar : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;

    private GameObject aoeDisplayGameobject;

    protected override void displayAoe()
    {
        castTime = 6;
        actionTime = 4;
        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //We show the castbar on the hud
        GameManager.getInstance().startEnemyAbility(castTime, "Titanic Roar");

        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //The boss looks at the player while casting
        GetComponent<LookAtPlayer>().setIsLooking(true);
    }

    protected override void doAction()
    {
        //Stops looking at player
        GetComponent<LookAtPlayer>().setIsLooking(false);

        //Play the sound
        GetComponent<AudioSource>().Play();

        GameManager.getInstance().playerLoseLife(5);

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        Destroy(aoeDisplayGameobject);
    }

    protected override void stopAction()
    {
    }
}