using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPelet : MonoBehaviour {

    Renderer rend;
	
    // Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();	
	}
	
	// Update is called once per frame
	void Update () {
        Flash();   
    }

    void Flash()
    {
        bool oddeven = Mathf.FloorToInt(Time.time * 5) % 2 == 0;
        rend.enabled = oddeven;
    }

   /* void OnCollsionEnter(Collision collision)
    {
        PCcontroller pacman = collision.gameObject.GetComponent<PCcontroller>();
        if (pacman)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }*/
}
