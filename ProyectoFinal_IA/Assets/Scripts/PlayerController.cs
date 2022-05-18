using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool input = true;
    bool isAttacking = false;

    [SerializeField]
    private float speed;

    float deltaX, deltaZ;
    float horizontalCamera;
    
    void Update()
    {
        //Giro de camara
        if (Input.GetMouseButton(1))
        {
            horizontalCamera = Input.GetAxis("Mouse X");
            transform.Rotate(0, horizontalCamera, 0);

            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetMouseButtonUp(1))
            Cursor.lockState = CursorLockMode.None;

        if (input)
        {
            deltaX = Input.GetAxis("Horizontal") * speed;
            deltaZ = Input.GetAxis("Vertical") * speed;
            transform.Translate(deltaX, 0, deltaZ);
        }
        else
        {
            deltaX = 0;
            deltaZ = 0;
        }

        //Si pulsas el espacio...
        if (Input.GetButtonDown("Jump"))
        {
            isAttacking = true;
            GameManager.getInstance().playerAttack(3);
        }
        if (isAttacking && (deltaX != 0 || deltaZ != 0))
        {
            GameManager.getInstance().stopPlayerAttack();
            isAttacking = false;
        }        
        


    }

    public void blockInput()
    {
        input = false;
    }
    public void allowInput()
    {
        input = true;
    }
}
