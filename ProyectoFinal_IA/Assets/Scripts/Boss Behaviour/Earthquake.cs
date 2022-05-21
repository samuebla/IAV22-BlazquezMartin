using UnityEngine;

public class Earthquake : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;

    [SerializeField]
    private GameObject displaySphereCollider;

    private GameObject aoeDisplayGameobject;

    //Redefinimos el tiempo de casteo y de la acción
    protected new float castTime = 4;
    protected new float actionTime = 4;

    protected override void displayAoe()
    {

        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //Mostramos el casteo de la habilidad en la interfaz
        GameManager.getInstance().startEnemyAbility(castTime, "Earthquake");

        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //Mientras prepara el ataque, mira constantemente al jugador
        GetComponent<LookAtPlayer>().setIsLooking(true);

        Debug.Log("Se empieza a mostrar el area de efecto");
    }

    protected override void doAction()
    {
        //Al hacer el ataque, deja de mirar al jugador
        GetComponent<LookAtPlayer>().setIsLooking(false);

        //Instanciamos el elemento que hace daño
        Instantiate<GameObject>(displaySphereCollider);

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        Destroy(aoeDisplayGameobject);
        Debug.Log("Se empieza a hacer la accion");
    }

    protected override void stopAction()
    {
        Debug.Log("Se para la accion");
    }
}