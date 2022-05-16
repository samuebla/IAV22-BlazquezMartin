using UnityEngine;

public class Earthquake : BossAction
{
    protected override void displayAoe()
    {
        Debug.Log("Se empieza a mostrar el area de efecto");
    }

    protected override void doAction()
    {
        Debug.Log("Se empieza a hacer la accion");
    }

    protected override void stopAction()
    {
        Debug.Log("Se para la accion");
    }
}