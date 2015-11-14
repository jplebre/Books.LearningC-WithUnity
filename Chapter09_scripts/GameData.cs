using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour 
{
	private int playerLivesSelected = 1;
	private int sceneBeginningScore;

	//Stores the splash screens images
	//ready to be called
	public Texture2D beginStateSplash;
	public Texture2D lostStateSplash;
	public Texture2D wonStateSplash;

	//Storing a list of cameras
	//Inactive cameras can't be found by Unity so we need to store them here
	public List<GameObject> cameras;

	//following variables need to be public but shouldn't show up on the inspector
	[HideInInspector]
	public int playerLives;
	[HideInInspector]
	public int score;

	[HideInInspector]
	public Rigidbody hoverCraftPhysics;
	public GameObject hoverCraft;


	//initializing variable
	void Start () 
	{
		playerLives = playerLivesSelected;
		hoverCraftPhysics = GameObject.Find("HoverCraft").GetComponent<Rigidbody>();
		hoverCraft = GameObject.Find ("HoverCraft");
	}


	public void ResetPlayer()
	{
		playerLives = playerLivesSelected;
		score = sceneBeginningScore;
	}

	public void SetPlayerLives(int livesSelected)
	{
		playerLivesSelected = livesSelected;
		playerLives = livesSelected;
	}

	public void SetScore()
	{
		sceneBeginningScore = score;
	}
}
