using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public SimpleTouchController Controller;
    public Rigidbody rb;
    Vector3 movement;
    private Vector2 crosshair;
    int floorMask;
    float camRayLength = 100f;
    public GameObject fireball;
    public Transform staff;
    public float fireRate;
    private float nextFire;
    private Vector3 lookRot;
    public GameObject joystick;
    public float speed;
    public bool buttonDown;
    Animator anim;
    public GUISkin customGui;


    void Start()
    {

        buttonDown = false;
        floorMask = LayerMask.GetMask("Floor");
        crosshair = new Vector2(Screen.width / 2, Screen.height / 2);
        joystick = GameObject.FindWithTag("TouchController");
        Controller = joystick.GetComponent<SimpleTouchController>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Awake()
    {

    }

    void FixedUpdate()
    {

        float h = Controller.GetTouchPosition.x;
        float v = Controller.GetTouchPosition.y;

        Vector3 movement = new Vector3(h, 0.0f, v).normalized;

        if (h != 0.0f || v != 0.0f)
        {
            lookRot = movement;
        }
        if (movement != Vector3.zero)
        {
            Quaternion directionRotation = Quaternion.LookRotation(lookRot);
            rb.MoveRotation(directionRotation);
        }

        rb.AddForce(movement * speed);

        Animating(h,v);
    }

    void Update()
    {
        //Turning();                    

    }


    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(crosshair);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }


    }
    void Animating(float h, float v)
    {
        bool walking = h != 0.0f || v != 0.0f;
        anim.SetBool("IsWalking", walking);
    }

 
    void OnGUI()
    {
        GUI.skin = customGui;
        if (GUI.Button(new Rect(960, 0, 960, 1080), " ") && Time.time > nextFire)
        {
            GUI.skin = customGui;
            nextFire = Time.time + fireRate;
            CmdShoot(staff.position, staff.rotation);
            Debug.Log("buttondown");
        }
    }



    [Command]
    void CmdShoot(Vector3 position, Quaternion rotation)
    {
        Debug.Log("shooting  "+ "islocalplayer? " + isLocalPlayer);

        var bullet = (GameObject)Instantiate(
            fireball,
            position,
            rotation);


        NetworkServer.Spawn(bullet);
    }

}