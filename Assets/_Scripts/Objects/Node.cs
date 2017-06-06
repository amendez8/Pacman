using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    //[System.NonSerialized]
    public int nodeID;
    private float heuristic;
    //[System.NonSerialized]
    public List<bool> explored = new List<bool>();
    private float distanceSoFar;
    private int heapIndex;
    //[System.NonSerialized]
    public List<Node> backReference = new List<Node>();
    public List<Node> neighbors = new List<Node>();

    public Node cluster;

    public LayerMask unWalkable;
    bool walk;
    public bool cantWalk;


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.FindGameObjectWithTag("Pathfinder").GetComponent<Pathfinder>().SetGoalNode(this);
        }
    }

    // Use this for initialization
    void Start () {

        heuristic = -1;

       /* // destroy tiles under walls, prevents Ghosts from using them
        walk = !(Physics.CheckSphere(transform.position, 0.5f, unWalkable));
        if (walk == false)
            Destroy(gameObject);*/
    }

    public static bool operator >(Node one, Node two)
    {
        if (one.heuristic > two.heuristic)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator <(Node one, Node two)
    {
        if (one.heuristic < two.heuristic)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator >=(Node one, Node two)
    {
        if (one.heuristic >= two.heuristic)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator <=(Node one, Node two)
    {
        if (one.heuristic <= two.heuristic)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public int CompareTo(Node nodeToCompare)
    {
        //return HeapIndex.CompareTo(nodeToCompare.HeapIndex);
        int compare = TotalCost.CompareTo(nodeToCompare.TotalCost);
        if (compare == 0)
        {
            compare = heuristic.CompareTo(nodeToCompare.heuristic);
        }
        return -compare;
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public float TotalCost
    {
        get
        {
            return (heuristic + distanceSoFar);
        }
    }

    public float Heuristic
    {
        get
        {
            return heuristic;
        }

        set
        {
            heuristic = value;
        }
    }



    public float DistanceSoFar
    {
        get
        {
            return distanceSoFar;
        }

        set
        {
            distanceSoFar = value;
        }
    }
    /*
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Wall")
            Object.Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
            Object.Destroy(gameObject);
    }

    public void wallOnTop()
    {
        RaycastHit hit;
        float width = GetComponent<MeshRenderer>().bounds.size.x;
        if (Physics.SphereCast(transform.position, width, new Vector3(0, 1, 0), out hit, 14))
        {
            if (hit.transform.tag == "Wall") Object.Destroy(gameObject);
        }
    }*/

    public bool heuristicNotComputed()
    {
        return Heuristic == -1;
    }

}
