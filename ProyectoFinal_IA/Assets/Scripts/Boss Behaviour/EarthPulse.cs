using UnityEngine;

public class EarthPulse : BossAction
{

    [SerializeField]
    private GameObject tiles;

    protected override void displayAoe()
    {
        castTime = 5;
        actionTime = 5;

        int contador = 0;
        int randomTile = (int)(Random.value * 35);

        //We show the castbar in the hud
        GameManager.getInstance().startEnemyAbility(castTime, "Earth Pulse");

        foreach (EarthPulseTile tile in tiles.GetComponentsInChildren<EarthPulseTile>())
        {
            if (contador == randomTile)
            {
                tile.manualActivate();

                break;
            }
            contador++;
        }
        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //The boss looks at the player
        GetComponent<LookAtPlayer>().setIsLooking(true);
    }

    protected override void doAction()
    {
        //Stops looking at player
        GetComponent<LookAtPlayer>().setIsLooking(false);

        //Play the sound
        GetComponent<AudioSource>().Play();

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);
    }

    protected override void stopAction()
    {
    }
}