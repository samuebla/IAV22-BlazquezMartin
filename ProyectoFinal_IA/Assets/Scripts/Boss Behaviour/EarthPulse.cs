using UnityEngine;

public class EarthPulse : BossAction
{

    [SerializeField]
    private GameObject tiles;

    protected new float castTime = 5;
    protected new float actionTime = 5;
    protected override void displayAoe()
    {
        int contador = 0;
        int randomTile = (int)(Random.value * 35);

        //Mostramos el casteo de la habilidad en la interfaz
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

        //Al preparar el ataque, se queda mirando al jugador
        GetComponent<LookAtPlayer>().setIsLooking(true);

        Debug.Log("Se empieza a mostrar el area de efecto");
    }

    protected override void doAction()
    {
        //Al hacer el ataque, deja de mirar al jugador
        GetComponent<LookAtPlayer>().setIsLooking(false);

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        Debug.Log("Se empieza a hacer la accion");
    }

    protected override void stopAction()
    {
        Debug.Log("Se para la accion");
    }
}