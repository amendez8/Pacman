using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1PointSystem : MonoBehaviour {

    private int points;
    private Text p1Score;

	// Use this for initialization
	void Start () {
        p1Score = GetComponent<Text>();
        Restart();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            points += 10;
            p1Score.text = points.ToString();
        }
    }
	
	public void Points()
    {
        points += 10;
        p1Score.text = points.ToString();
    }

    public void Restart()
    {
        points = 0;
        p1Score.text =  points.ToString();
    }

    public int returnPoints()
    {
        return points;
    }
}
