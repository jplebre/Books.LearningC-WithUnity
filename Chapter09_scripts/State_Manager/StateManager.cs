/* Based on the StateManager script from Learning C# By Developing Games with Unity
 * Create an empty Game Object to place this script on.
 * Make sure folder hierarchy for interface and states script is followed
 */

using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;
using Assets.Scripts.State_Manager.States;

public class StateManager : MonoBehaviour 
{
	private IStateBase activeState;
	private static StateManager managerInstanceRef;

	[HideInInspector]
	public GameData gameDataRef;


	void Awake()
	{
		//on Load, this object is created
		//We are ensuring it's not overwritten or destroyed when loading scenes/states
		if (managerInstanceRef == null)
		{
			managerInstanceRef = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			DestroyImmediate(gameObject);
	}


	void Start()
	{
		//starts BeginState, sets it to active state
		//passes this script - statemanager - to BeginState so it can use it as reference
		activeState = new BeginState(this);
		gameDataRef = GetComponent<GameData>();
	}


	void Update()
	{
		//for each frame of the game, we force the active state to do what it has to do
		//every state HAS TO have a StateUpdate(), where the code lives
		if (activeState != null)
			activeState.StateUpdate ();
	}


	void OnGUI()
	{
		//OnGui is something Unity calls at least once per frame
		//Used to update graphic displays (huds) or send messages/update texts
		if (activeState != null)
			activeState.ShowIt();
	}


	public void SwitchState(IStateBase newState)
	{
		//if the activeState decides it needs to change to another state
		//this function is called, and the manager updates the activeState reference
		activeState = newState;
	}


	public void Restart()
	{
		//called when player lost or won all levels and decided not to continue.
		//Game reboots all it's info and goes back to BeginState
		Destroy (gameObject);
		Application.LoadLevel("Scene_0");
	}
}
