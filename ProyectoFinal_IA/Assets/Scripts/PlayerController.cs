using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool input = true;
    Rigidbody rb;

    [SerializeField]
    private float speed;

    float deltaX, deltaZ;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Para las fisicas
    private void FixedUpdate()
    {
        if (input)
        {
            rb.velocity = new Vector3(deltaX, 0, deltaZ);
        }
    }


    void Update()
    {
        //Giro de camara


        if (input)
        {
            deltaX = Input.GetAxis("Horizontal") * speed;
            deltaZ = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            deltaX = 0;
            deltaZ = 0;
        }



    }
}
