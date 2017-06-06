using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class SetLocalPlayer : NetworkBehaviour {

    [SyncVar]
    public string pname = "player";

	// Use this for initialization
	void Start () {
        if (isLocalPlayer)
            GetComponent<PCcontroller>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (pname == "Player1")
            gameObject.tag = "Player1";
        if (pname == "Player2")
            gameObject.tag = "Player2";
    }
}
