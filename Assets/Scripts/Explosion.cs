using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Explosion : NetworkBehaviour
{
    public float power = 1.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    void Start()
    {
        RpcDetonate();
    }

    // Update is called once per frame
    void Update()
    {

    }


    [ClientRpc]
    void RpcDetonate()
    {
        Debug.Log("detonating");
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {

            Rigidbody rib = hit.GetComponent<Rigidbody>();
            if (rib != null)
            {
                //more realistic explosion
                //rib.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);

                //gameplay (mechanic) favored explosion type (along fireball vector)
                rib.AddForce(gameObject.transform.forward * power, ForceMode.Impulse);
            }

        }
    }
}
