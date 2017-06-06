using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    /*public LayerMask unWalkable;
    float movementSpeed;
    Vector3 direction;
    Ray rayCast;

    // Use this for initialization
    void Start () {
        direction = new Vector3(0, 0, 0);
        movementSpeed = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Go();
        WallCheck();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = new Vector3(0, 0, -1);
            //transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = (new Vector3(0, 0, 1));
           // transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = (new Vector3(-1, 0, 0));
           // transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = (new Vector3(1, 0, 0));
           // transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5;
        }
    }

    void Go()
    {
        transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
    }

    void WallCheck()
    {
        RaycastHit hit;
        rayCast = new Ray(transform.position, transform.forward);
        Debug.DrawRay(rayCast.origin, rayCast.direction, Color.red);

        if (Physics.Raycast(rayCast, out hit, 0.6f, unWalkable))
        {
            movementSpeed = 0;
        }
    }

    void OnCollsionEnter(Collision collision)
    {
        PCcontroller pc = collision.gameObject.GetComponent<PCcontroller>();
        if (pc)
            Destroy(gameObject);
    }*/
}
