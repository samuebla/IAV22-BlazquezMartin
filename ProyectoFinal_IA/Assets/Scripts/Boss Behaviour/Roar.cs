using UnityEngine;

public class Roar : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;

    private GameObject aoeDisplayGameobject;

    protected override void displayAoe()
    {
        castTime = 4;
        actionTime = 3;
        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //We show the castbar on the hud
        GameManager.getInstance().startEnemyAbility(castTime, "Roar");

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

        int layerMask = 1 << 6;

        //Player collision check
        RaycastHit hit;
        if (!(Physics.Raycast(transform.position, (GetComponent<LookAtPlayer>().getPlayerPosition() - transform.position).normalized, out hit, Mathf.Infinity, layerMask)))
            GameManager.getInstance().playerLoseLife(1);

        GetComponent<EarthExpulsion>().doDamageToRocks();

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        Destroy(aoeDisplayGameobject);
    }

    protected override void stopAction()
    {
    }
}