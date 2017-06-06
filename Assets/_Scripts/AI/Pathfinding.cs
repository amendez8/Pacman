using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Pathfinding : MonoBehaviour
{


    NodeBinaryHeap openHeap;
    Node startNode;
    Node bestSoFar;
    bool heapOverflow = false;
    List<Node> path2Follow;
    Node goalNode;
    GameObject makerRef;
    private int maxNumNodes;

    private bool abort = false;

    void Start()
    {
        path2Follow = new List<Node>();
        makerRef = GameObject.Find("Start");
        Platform tempRef = makerRef.GetComponent<Platform>();
        maxNumNodes = tempRef.gridX * tempRef.gridY;
        openHeap = new NodeBinaryHeap(2048);
    }

    GameObject findClosestNode()
    {

        GameObject returnNode = null;
        float closest = Mathf.Infinity;
        float candidateDistance;
        for (int i = 0; i < makerRef.transform.childCount; ++i)
        {

            Transform candidateNode = makerRef.transform.GetChild(i);
            candidateDistance = (candidateNode.position - transform.position).sqrMagnitude;
            if (candidateDistance < closest)
            {
                closest = candidateDistance;
                returnNode = candidateNode.gameObject;
            }
        }
        // Debug.Log("Hello Friends");
        return returnNode;
    }

    void CalculateHeuristic(Node target, Node goal)
    {
        float hValue;
        //Euclidean distance
        hValue = (int)(goal.GetComponentInParent<Transform>().position -
            target.GetComponentInParent<Transform>().position).magnitude;

        target.Heuristic = hValue;
    }

    public List<Node> FindPath(Node goal, int NPCID)
    {

        CleanUp(NPCID);

        startNode = findClosestNode().GetComponent<Node>();
        bestSoFar = startNode;
        goalNode = goal;

        //We're defining the Heuristic to be 0 on the goal node, regardless of heuristic used.
        goalNode.Heuristic = 0;
        Node focus;
        //PathfindingNode focus = startNode.GetComponent<PathfindingNode>();
        openHeap.Add(startNode.GetComponent<Node>());
        //Loop continues until either the openList is empty or the goal node is reached

        //we need a check to see if the focus == the goal

        while (openHeap.currentItemCount != 0)
        {


            focus = openHeap.Remove();
            //Debug.Log(focus);
            if (focus != null)
            {
                foreach (Node neighbor in focus.neighbors)
                {
                    if (neighbor.cantWalk == false) // if false, means there is a wall
                        continue;
                    //  Debug.Log(neighbor.nodeID);
                    if (neighbor.Heuristic == -1) { CalculateHeuristic(neighbor, goalNode); }
                    //if the neighbor is not explored OR if we have a better path
                    if ((!neighbor.explored[NPCID]) || ((neighbor.Heuristic + focus.DistanceSoFar) < neighbor.TotalCost))
                    {
                        if ((neighbor.TotalCost < bestSoFar.TotalCost)
                            || (bestSoFar.Heuristic == -1))
                        { bestSoFar = neighbor; }
                        neighbor.DistanceSoFar = focus.DistanceSoFar + 1;
                        neighbor.backReference[NPCID] = focus;
                        if ((!heapOverflow) && (openHeap.currentItemCount < openHeap.items.Length)) { openHeap.Add(neighbor); }
                        else { heapOverflow = true; }

                    }

                }
                // Debug.Log(openHeap.currentItemCount);
                focus.explored[NPCID] = true;
                if ((focus.nodeID == goalNode.nodeID))
                {
                    List<Node> finalPath = new List<Node>();
                    while (focus.backReference[NPCID].nodeID != startNode.nodeID)
                    {
                        finalPath.Insert(0, focus);
                        //finalPath.Add(focus.BackReference);
                        focus = focus.backReference[NPCID];
                    }
                    path2Follow = finalPath;
                    DrawPathfinding(NPCID);

                    return finalPath;
                }
            }



        }
        //if we've reached this point, then the openlist search space became too large at some point
        //And our new aim is to return the path leading to the node with the most potential to lead to a path in the future.

        List<Node> finalPath2 = new List<Node>();
        //Need to know if we reached the goal or not.

        //Now we follow the backreferences we've been setting whenever we updated a node
        //until we reach the initial node, this gives us a path.

        while (bestSoFar.backReference[NPCID].nodeID != startNode.nodeID)
        {
            finalPath2.Insert(0, bestSoFar);
            bestSoFar = bestSoFar.backReference[NPCID];
        }
        path2Follow = finalPath2;
        DrawPathfinding(NPCID);

        return finalPath2;
    }

    public void SetGoal(Node incomingNode)
    {
        goalNode = incomingNode;
    }

    void DrawPathfinding(int NPCID)
    {
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            if (node.GetComponent<Node>().explored[NPCID] == true)
            {
                //node.GetComponent<Renderer>().material.color = new Color(1.0f,0.0f,0.0f,1.0f);
            }
        }




        foreach (Node node3 in openHeap.items)
        {
            if (node3 != null)
            {
                //node3.gameObject.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            }
        }
        foreach (Node node2 in path2Follow)
        {
            node2.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }
        startNode.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 1.0f, 1.0f);
        goalNode.gameObject.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    }

    void CleanUp(int NPCID)
    {

        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Node"))
        {
            Node cache = node.GetComponent<Node>();
            cache.explored[NPCID] = false;
            cache.Heuristic = -1;
            if (cache.backReference.Count > 0)
            { cache.backReference[NPCID] = null; }
            node.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        openHeap = new NodeBinaryHeap(2048);
        openHeap.currentItemCount = 0;

    }

}
