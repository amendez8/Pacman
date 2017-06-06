using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCcontroller : MonoBehaviour {

    public LayerMask unWalkable;
    public AudioClip powerPeletSound;
    float speedMultiplier;
    float movementSpeed;
    Vector3 direction;
    Ray rayCast;

    // Use this for initialization
    void Start () {
        direction = new Vector3(0, 0, 0);
        movementSpeed = 5.0f;
        speedMultiplier = 1.0f;
        transform.position = new Vector3(-48.8f, 0.684f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        Go();
        WallCheck();
        OutOfBoundsCheck();        
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = new Vector3(0, 0, -1);
            transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5.0f;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = (new Vector3(0, 0, 1));
            transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5.0f;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = (new Vector3(-1, 0, 0));
            transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5.0f;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = (new Vector3(1, 0, 0));
            transform.rotation = Quaternion.LookRotation(direction);
            movementSpeed = 5.0f;
        }
    }

    void Go()
    {
        transform.Translate(direction * movementSpeed * speedMultiplier * Time.deltaTime, Space.World);
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

    void OutOfBoundsCheck()
    {
        if (transform.position.z >= 1.0f) // if in bottom half
        {
           // if (transform.position.x >= -35.0f)
             //   transform.position = new Vector3(-63.3f, transform.position.y, transform.position.z);

            if (transform.position.x <= -63.3f)
                transform.position = new Vector3(-35.276f, transform.position.y, transform.position.z);
        }

        if (transform.position.z <= 1.0f) // if in top half
        {
            //if (transform.position.x >= -35.0f)
              //  transform.position = new Vector3(-63.3f, transform.position.y, transform.position.z);

            if (transform.position.x <= -63.3f)
                transform.position = new Vector3(-35.276f, transform.position.y, transform.position.z);
        }
    }

    IEnumerator ResetSpeedMultiplier()
    {
        yield return new WaitForSeconds(4);
        speedMultiplier = 1.0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        PowerPelet pp = collision.gameObject.GetComponent<PowerPelet>();
        Ghost g = collision.gameObject.GetComponent<Ghost>();
        LeftWall wall = collision.gameObject.GetComponent<LeftWall>();

        if (pp)
        {
            speedMultiplier = 1.5f;
            StartCoroutine(ResetSpeedMultiplier());
            pp.gameObject.SetActive(false);
            Destroy(pp);
            AudioSource.PlayClipAtPoint(powerPeletSound, transform.position);
        }

        if (wall)
        {
            if (transform.position.z >= 1.0f || transform.position.z <= 1.0f) // if in bottom half or bottom half
                transform.position = new Vector3(-63.3f, transform.position.y, transform.position.z);
        }

        if (g)
        {
            /* g.gameObject.SetActive(false);
             Destroy(g);*/
            transform.position = new Vector3(-30.8f, transform.position.y, 35.97f);
            movementSpeed = 0;
            Debug.Log("collide with ghost");
        }
    }

}
