using UnityEngine;

public class EarthExpulsion : BossAction
{
    [SerializeField]
    private GameObject leftRockPrefab;

    [SerializeField]
    private GameObject rightRockPrefab;

    [SerializeField]
    private GameObject aoeDisplayPrefabLeft;

    [SerializeField]
    private GameObject aoeDisplayPrefabRight;

    private GameObject aoeDisplayGameobjectLeft;
    private GameObject aoeDisplayGameobjectRight;

    //Redefinimos el tiempo de casteo y de la acción
    protected new float castTime = 4;
    protected new float actionTime = 4;

    protected override void displayAoe()
    {
        aoeDisplayGameobjectLeft = Instantiate<GameObject>(aoeDisplayPrefabLeft);
        aoeDisplayGameobjectRight = Instantiate<GameObject>(aoeDisplayPrefabRight);

        //Mostramos el casteo de la habilidad en la interfaz
        GameManager.getInstance().startEnemyAbility(castTime, "Earth Expulsion");
    }

    protected override void doAction()
    {
        //Instanciamos el elemento que hace daño
        Instantiate<GameObject>(leftRockPrefab);
        Instantiate<GameObject>(rightRockPrefab);
        //Instantiate<GameObject>(displaySphereCollider);

        Destroy(aoeDisplayGameobjectLeft);
        Destroy(aoeDisplayGameobjectRight);
    }

    protected override void stopAction()
    {
        
    }
}