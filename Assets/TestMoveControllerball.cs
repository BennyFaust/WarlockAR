using UnityEngine;
using System.Collections;

public class TestMoveControllerball : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    public SimpleTouchController Controller;
    public GameObject joystick;

    void Start()
    {
        joystick = GameObject.FindWithTag("TouchController");
        rb = GetComponent<Rigidbody>();
        Controller = joystick.GetComponent<SimpleTouchController>();
    }

    void FixedUpdate()
    {
        float h = Controller.GetTouchPosition.x;
        float v = Controller.GetTouchPosition.y;

        Vector3 movement = new Vector3(h, 0.0f, v).normalized;

        rb.AddForce(movement * speed);
    }
}