using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    public Transform respawn;
    private Vector3 originalPos;

    private void Start()
    {
        originalPos = new Vector3(respawn.transform.position.x, respawn.transform.position.y, respawn.transform.position.z);
    }


    void OnTriggerExit(Collider other)
    {
        Debug.Log(other + " destroyed!");
        if (other.gameObject.tag != "Player")
        {
            Destroy(other.gameObject);
        }else{
            other.gameObject.transform.position = originalPos;
        }
    }
}