using UnityEngine;

public class Rockbuster : BossAction
{

    protected override void displayAoe()
    {
        castTime = 4;
        actionTime = 3;

        //We show the castbar on the hud
        GameManager.getInstance().startEnemyAbility(castTime, "Rockbuster");

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
        if ((Physics.Raycast(transform.position + new Vector3(0, 2, 0), ((GetComponent<LookAtPlayer>().getPlayerPosition() + new Vector3(0, 0.5f, 0)) - (transform.position + new Vector3(0, 2, 0))).normalized * 100,
            out hit, Mathf.Infinity, layerMask)))
            GameManager.getInstance().playerLoseLife(1);
        else if (hit.collider.gameObject.GetComponent<RockHealth>() != null)
        {
            hit.collider.gameObject.GetComponent<RockHealth>().loseHealth();
        }
        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_01", true);
    }

    protected override void stopAction()
    {
    }
}