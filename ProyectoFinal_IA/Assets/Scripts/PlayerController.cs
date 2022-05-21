using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool input = true;
    bool isAttacking = false;
    float timer = 0;

    [SerializeField]
    private float speed;

    float deltaX, deltaZ;
    float horizontalCamera;

    private Transform cameraPosition;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        GameManager.getInstance().setPlayer(this.gameObject);
        cameraPosition = GetComponentInChildren<Camera>().gameObject.GetComponent<Transform>();
    }

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

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && ((cameraPosition.position - transform.position).magnitude < 15 && (cameraPosition.position - transform.position).magnitude > -15))
        {
            cameraPosition.Translate(0, 0, -1);
            //cameraPosition.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, cameraPosition.position.z - 1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && ((cameraPosition.position - transform.position).magnitude > 4 || (cameraPosition.position - transform.position).magnitude < -4))
        {
            cameraPosition.Translate(0, 0, 1);
            //cameraPosition.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, cameraPosition.position.z + 1);
        }

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

        if (isAttacking)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                isAttacking = false;
                timer = 0;
            }
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
