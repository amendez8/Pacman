using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelet : MonoBehaviour {

    public AudioClip peletTaken;
    private P1PointSystem ps1;
    private P1PointSystem ps2;

	// Use this for initialization
	void Start () {
        ps1 = GameObject.Find("P1Score").GetComponent<P1PointSystem>();
        ps2 = GameObject.Find("P2Score").GetComponent<P1PointSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        SetLocalPlayer pacman = collision.gameObject.GetComponent<SetLocalPlayer>();

        if (pacman.pname == "Player1")
        {
            ps1.Points();
            
        }

        if (pacman.pname == "Player2")
        {
            ps2.Points();
        }
        AudioSource.PlayClipAtPoint(peletTaken, transform.position);
        Destroy(gameObject);
    }
}
