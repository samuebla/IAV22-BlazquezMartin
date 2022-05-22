using UnityEngine;

public class Rockbuster : BossAction
{

    protected override void displayAoe()
    {
        castTime = 4;
        actionTime = 4;

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

        int layerMask = 1 << 6;

        //Player collision check
        RaycastHit hit;
        if (!(Physics.Raycast(transform.position, (GetComponent<LookAtPlayer>().getPlayerPosition() - transform.position).normalized, out hit, Mathf.Infinity, layerMask)))
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