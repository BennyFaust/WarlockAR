using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject snow;
    public float iceAmount = 0.0f;
    Material mySnowMaterial;

    private const string PLAYER_ID_PREFIX = "Player ";

    private static Dictionary<string, PlayerController> players = new Dictionary<string, PlayerController>();

    public static void RegisterPlayer (string _netID, PlayerController _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }

    public static PlayerController GetPlayer (string _playerID)
    {
        return players[_playerID];
    }


    private void Start()
    {
        mySnowMaterial = snow.GetComponent<Renderer>().material;
    }


    private void Update()
    {
        DissolveSnow();
    }

    public void DissolveSnow(){
        if (iceAmount <= 1.0f){
            iceAmount = iceAmount + 0.00005f;
            mySnowMaterial.SetFloat("_SliceAmount", iceAmount);
            Debug.Log(iceAmount);
        }
    }
}
