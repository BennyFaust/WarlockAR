using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float firespeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * firespeed;
    }
}