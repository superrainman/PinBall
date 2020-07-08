using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	public int score = 0;
	private GameObject scoreBoard;

	// Use this for initialization
	void Start () 
	{
		this.scoreBoard = GameObject.Find("ScoreBoard");

	}
	
	// Update is called once per frame
	void Update () 
	{
		this.scoreBoard.GetComponent<Text> ().text = "SCORE " + score;	
	}

	public void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "SmallStarTag")
		{
			score += 10;
		}

		if (collision.gameObject.tag == "LargeStarTag")
		{
			score += 50;
		}

		if (collision.gameObject.tag == "SmallCloud")
		{
			score += 80;
		}

		if (collision.gameObject.tag == "LargeCloud")
		{
			score += 200;
		}


	}


}
