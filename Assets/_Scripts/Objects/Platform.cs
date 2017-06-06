using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public GameObject markers;
    //public LayerMask unWalkable;

    public LayerMask unWalkable;
    public int gridX = 28;
    public int gridY = 31;
    public int gridsize;
    private bool walk;

    // Use this for initialization
    void Start () {
        makeGrid();
        gridsize = gridX * gridY;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void makeGrid()
    {
        GameObject[,] tempGrid = new GameObject[gridX, gridY];

        float cubeScale = 29.0f / 28.0f;
        for (int i = 0; i < gridX; i++)
        {
            for(int j = 0; j < gridY; j++)
            {
                GameObject tile = (GameObject)Instantiate(markers,
                    new Vector3(-50f + (0.5f * cubeScale) + (cubeScale * i),
                    0f,
                    50f - (0.5f * cubeScale) - cubeScale * j),
                    Quaternion.identity);
                tile.GetComponent<Node>().nodeID  = (i * 10) + j;
                tile.transform.SetParent(transform);
                
                bool walk = !(Physics.CheckSphere(tile.transform.position, 0.5f, unWalkable));
                if (walk == false)
                    tile.GetComponent<Node>().cantWalk = walk;
                else
                    tile.GetComponent<Node>().cantWalk = true;
                 

                tempGrid[i, j] = tile;
                //Node.wallOnTop();
                //Node.explored = new List<bool>(new bool[enemies.Length]);
                //pathfindingNode.backReference = new List<Node>(new Node[enemies.Length]);
            }
        }

        for (int i = 0; i < gridX; ++i)
        {
            for (int j = 0; j < gridY; ++j)
            {
                Node reference = tempGrid[i, j].GetComponent<Node>();
                if ((i + 1) < gridX) { reference.neighbors.Add(tempGrid[i + 1, j].GetComponent<Node>()); }
                if ((j + 1) < gridY) { reference.neighbors.Add(tempGrid[i, j + 1].GetComponent<Node>()); }
                if ((i - 1) >= 0) { reference.neighbors.Add(tempGrid[i - 1, j].GetComponent<Node>()); }
                if ((j - 1) >= 0) { reference.neighbors.Add(tempGrid[i, j - 1].GetComponent<Node>()); }
            }
            
        }
    }
}
