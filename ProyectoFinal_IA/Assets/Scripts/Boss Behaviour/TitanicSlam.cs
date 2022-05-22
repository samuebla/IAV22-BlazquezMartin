using UnityEngine;

public class TitanicSlam : BossAction
{
    [SerializeField]
    private GameObject [] aoeDisplayPrefab;

    [SerializeField]
    private GameObject playerRef;

    private GameObject aoeDisplayGameobject;

    [SerializeField]
    private Transform[] positions;

    [SerializeField]
    private Transform origin;

    bool goingToCenter = false;
    bool startMoving = false;
    Vector3 jumpPosition;

    protected override void displayAoe()
    {
        castTime = 6;
        actionTime = 4;

        //We show the castbar on the hud
        GameManager.getInstance().startEnemyAbility(castTime, "Titanic Slam");

        //Select a random position to jump
        int randomPosition = (int)(Random.value * 3);

        aoeDisplayGameobject = Instantiate<GameObject>(aoeDisplayPrefab[randomPosition]);

        jumpPosition = positions[randomPosition].position;

        GetComponent<Animator>().SetBool("idle", false);
        GetComponent<Animator>().SetBool("defy", true);

        //The boss looks at the jumpPosition while casting
        transform.LookAt(jumpPosition);
    }

    protected override void doAction()
    {
        startMoving = true;

        //Play the sound
        GetComponent<AudioSource>().Play();

        GetComponent<Animator>().SetBool("defy", false);
        //Jump
        GetComponent<Animator>().SetBool("jump", true);



        Destroy(aoeDisplayGameobject);
    }

    private void LateUpdate()
    {
        if (startMoving)
        {
            // Move the object forward along its z axis 1 unit/second.
            transform.Translate(jumpPosition.normalized * Time.deltaTime * 20,Space.World);
            if (transform.position.magnitude > jumpPosition.magnitude)
            {
                playerRef.GetComponent<Rigidbody>().AddForce((playerRef.transform.position - jumpPosition).normalized * 1250);

                //Block input until it finished
                playerRef.GetComponent<PlayerController>().blockInput();

                startMoving = false;
                goingToCenter = true;
                GetComponent<Animator>().SetBool("jump", false);
                GetComponent<Animator>().SetBool("walk", true);
                transform.LookAt(origin);
            }
        }
        if (goingToCenter)
        {
            // Move the object forward along its z axis 1 unit/second.
            transform.Translate((jumpPosition.normalized*-1) * Time.deltaTime * 10 , Space.World);
            if (transform.position.magnitude < 0.1)
            {
                goingToCenter = false;
                GetComponent<Animator>().SetBool("walk", false);
                GetComponent<Animator>().SetBool("idle", true);
                transform.position = origin.position;
            }
        }
    }

    protected override void stopAction()
    {
        playerRef.GetComponent<PlayerController>().allowInput();
    }

    private void OnDisable()
    {
        if (aoeDisplayGameobject)
            Destroy(aoeDisplayGameobject);
    }
}