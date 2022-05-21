using UnityEngine;

public class Landslide : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;

    [SerializeField]
    private GameObject displaySphereCollider;

    private GameObject aoeDisplayGameobject;

    //Redefinimos el tiempo de casteo y de la acción
    protected new float castTime = 3;
    protected new float actionTime = 3;

    protected override void displayAoe()
    {
        //Creamos el area de efecto
        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //Mostramos el casteo de la habilidad en la interfaz
        GameManager.getInstance().startEnemyAbility(castTime, "Landslide");

        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //Mientras prepara el ataque, mira constantemente al jugador
        GetComponent<LookAtPlayer>().setIsLooking(true);

        //Testing
        Debug.Log("Se empieza a mostrar el area de efecto");
    }

    protected override void doAction()
    {
        //Al hacer el ataque, deja de mirar al jugador
        GetComponent<LookAtPlayer>().setIsLooking(false);

        Destroy(aoeDisplayGameobject);

        GetComponent<Animator>().SetBool("defy", false);
        GetComponent<Animator>().SetBool("attack_03", true);

        //Instanciamos un prefab para que el jugador no pierda vida si está dentro del mismo
        Instantiate<GameObject>(displaySphereCollider);

        Debug.Log("Se empieza a hacer la accion");
    }

    protected override void stopAction()
    {
        Debug.Log("Se para la accion");
    }
}