using UnityEngine;

public class EarthPulse : BossAction
{
    protected new float castTime = 5;
    protected new float actionTime = 5;
    protected override void displayAoe()
    {
        int contador = 0;
        int randomTile = (int)(Random.value * 35);
        foreach (EarthPulseTile tile in gameObject.GetComponentsInChildren<EarthPulseTile>())
        {
            if (contador == randomTile)
            {
                tile.manualActivate();

                break;
            }
            contador++;
        }
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