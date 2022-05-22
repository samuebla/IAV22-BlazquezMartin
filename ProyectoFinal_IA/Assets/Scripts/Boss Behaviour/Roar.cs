using UnityEngine;

public class Roar : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;

    private GameObject aoeDisplayGameobject;

    //Redefinimos el tiempo de casteo y de la acción
    protected new float castTime = 4;
    protected new float actionTime = 4;

    protected override void displayAoe()
    {

        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //Mostramos el casteo de la habilidad en la interfaz
        GameManager.getInstance().startEnemyAbility(castTime, "Roar");

        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //Mientras prepara el ataque, mira constantemente al jugador
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

        GetComponent<EarthExpulsion>().doDamageToRocks();

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        Destroy(aoeDisplayGameobject);
    }

    protected override void stopAction()
    {
    }
}