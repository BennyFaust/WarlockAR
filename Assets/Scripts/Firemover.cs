using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Firemover : NetworkBehaviour
{
    public float firespeed;
    private Rigidbody rb;
    public float scrollSpeed;
    private Vector2 savedOffset;
    Material m_Material;
    private int timer = 0;
    public GameObject explosion;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        savedOffset = m_Material.GetTextureOffset("_MKGlowTex");
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * firespeed;
    }



    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        m_Material.SetTextureOffset("_MKGlowTex", offset);
        timer++;
        if (timer > 360)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (timer > 10)
        {
            CmdExplode(transform.position, transform.rotation);
            //not networked yet
            //Instantiate(explosion, transform.position, transform.rotation);
            //Detonate();
            //Destroy(gameObject);
        }
    }

    [Command]
    void CmdExplode(Vector3 position, Quaternion rotation)
    {
        var myexplosion = (GameObject)Instantiate(
    explosion,
    position,
    rotation);


        NetworkServer.Spawn(myexplosion);
        NetworkServer.Destroy(gameObject);
    }

    //void Detonate(){
    //    Debug.Log("detonating");
    //    Vector3 explosionPosition = transform.position;
    //    Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
    //    foreach(Collider hit in colliders){

    //        Rigidbody rib = hit.GetComponent<Rigidbody>();
    //        if (rib != null)
    //        {
    //            //realistic explosion
    //           // rib.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);

    //            //gameplay favored explosion type (along fireball vector)
    //            rib.AddForce(rb.velocity*10, ForceMode.Impulse);
    //        }

    //    }
    //}
}