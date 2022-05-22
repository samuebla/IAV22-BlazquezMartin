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

    private GameObject leftRock;
    private GameObject rightRock;

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
        leftRock = Instantiate<GameObject>(leftRockPrefab);
        rightRock = Instantiate<GameObject>(rightRockPrefab);
        //Instantiate<GameObject>(displaySphereCollider);

        Destroy(aoeDisplayGameobjectLeft);
        Destroy(aoeDisplayGameobjectRight);
    }

    protected override void stopAction()
    {
        
    }

    public Vector3 getLeftRockPosition()
    {
        return leftRock.transform.position;
    }

    public Vector3 getRightRockPosition()
    {
        return rightRock.transform.position;
    }

    public void doDamageToRocks()
    {
        if (leftRock)
            leftRock.GetComponent<RockHealth>().loseHealth();
        if (rightRock)
            rightRock.GetComponent<RockHealth>().loseHealth();
    }
}