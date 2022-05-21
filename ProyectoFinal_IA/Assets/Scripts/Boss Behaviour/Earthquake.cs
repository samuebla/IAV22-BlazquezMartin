using UnityEngine;

public class Earthquake : BossAction
{
    [SerializeField]
    private GameObject aoeDisplayPrefab;
    private GameObject aoeDisplayGameobject;
    protected override void displayAoe()
    {
        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab);

        //Mostramos el casteo de la habilidad en la interfaz
        GameManager.getInstance().startEnemyAbility(castTime, "Earthquake");

        Debug.Log("Se empieza a mostrar el area de efecto");
    }

    protected override void doAction()
    {
        Destroy(aoeDisplayGameobject);
        Debug.Log("Se empieza a hacer la accion");
    }

    protected override void stopAction()
    {
        Debug.Log("Se para la accion");
    }
}