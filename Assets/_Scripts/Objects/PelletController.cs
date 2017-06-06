using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PelletController : MonoBehaviour {

    public GameObject p1WinCanvas;
    public GameObject p2WinCanvas;
    public GameObject tiedCanvas;
    private P1PointSystem p1Score;
    private P1PointSystem p2Score;

	// Use this for initialization
	void Start () {
        p1Score = GameObject.Find("P1Score").GetComponent<P1PointSystem>();
        p2Score = GameObject.Find("P2Score").GetComponent<P1PointSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount <= 4)
        {
            if(p1Score.returnPoints() > p2Score.returnPoints())
                p1WinCanvas.SetActive(true);

            if (p1Score.returnPoints() < p2Score.returnPoints())
                p2WinCanvas.SetActive(true);

            if (p1Score.returnPoints() == p2Score.returnPoints())
                tiedCanvas.SetActive(true);
        }
	}
}
