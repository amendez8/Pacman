using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour
{

    private float seekSpeed = 20.0f;
    private float relativeSpeed;
    public Transform currentTarget;
    public List<Node> targetList = new List<Node>();
    public Node goalNode;
    public int NPCID;

    Vector3 goalFacing;             // if he has somewhere he needs to be looking
    float rotationSpeedRads = 10.0f; // speed at which he rotates
    Quaternion lookWhereYoureGoing; // look in direction of where he's going

    void Start()
    {
        NPCID = GameObject.FindGameObjectsWithTag("Pathfinder").Length - 1;
        // Debug.Log(NPCID);
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            node.GetComponent<Node>().explored.Add(false);
        }
        relativeSpeed = (GameObject.Find("Start").GetComponent<Platform>().gridsize) / 5.0f;
        //Debug.Log(relativeSpeed);
    }

    void Update()
    {

        //if no path, and have goal, find path.

        FollowPath();


        if (Input.GetKey(KeyCode.Space))
        {

        }
        if (Input.GetKey(KeyCode.Q))
        {

        }
        else if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.W))
        {

        }
        else if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.E))
        {

        }
        else if (Input.GetKey(KeyCode.D))
        {

        }
    }


    void Seek()
    {
        Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
        float realSpeed = seekSpeed * relativeSpeed;
        GetComponent<Rigidbody>().AddForce((direction * realSpeed/** relativeSpeed*/));
    }

    void Align()
    {
        goalFacing = (currentTarget.transform.position - transform.position).normalized;
        lookWhereYoureGoing = Quaternion.LookRotation(goalFacing, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookWhereYoureGoing, rotationSpeedRads);
    }

    void SetNewTarget()
    {
        if (targetList.Count == 0)
        {
            // Debug.Log("Pretty Princess Cupcake has reached her destination or gotten lost.");
        }
        else
        {
            currentTarget = targetList[0].GetComponentInParent<Transform>();
            targetList.RemoveAt(0);
            //Debug.Log(currentTarget.transform.position);
        }
    }

    void FollowPath()
    {
        if (goalNode != null)
        {
            if (targetList.Count == 0)
            {
                targetList = GetComponentInParent<Pathfinding>().FindPath(goalNode, NPCID);

                goalNode = null;
            }

        }
        if ((currentTarget == null) ||
            ((transform.position - currentTarget.position).sqrMagnitude < 1.0f))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            SetNewTarget();
        }
        if (currentTarget != null)
        {
            //Align();
            Seek();
        }
    }

    public void SetGoalNode(Node goalFromClickedNode)
    {
        goalNode = goalFromClickedNode;
    }
}
