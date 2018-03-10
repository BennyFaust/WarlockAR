using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerController))]
public class PlayerSetup : NetworkBehaviour {
    
    [SerializeField]
    Behaviour[] componentsToDisable;

    void Start()
    {

        if (!isLocalPlayer)
        {
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }

    }
    public override void OnStartClient(){
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        PlayerController _player = GetComponent<PlayerController>();


        GameManager.RegisterPlayer(_netID, _player);
    }

}
