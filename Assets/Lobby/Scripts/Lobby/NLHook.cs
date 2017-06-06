using System.Collections;
using Prototype.NetworkLobby;
using UnityEngine;
using UnityEngine.Networking;

public class NLHook : LobbyHook {

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lob = lobbyPlayer.GetComponent<LobbyPlayer>();
        SetLocalPlayer lp = gamePlayer.GetComponent<SetLocalPlayer>();

        lp.pname = lob.playerName;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
