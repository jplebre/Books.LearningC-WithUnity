using UnityEngine;
using Assets.Scripts.State_Manager.States;
using Assets.Scripts.State_Manager.Interfaces;
using System.Collections;

public class StateManager : MonoBehaviour {

	//we need a variable to store the current active state.
	//This variable also instatiates class with IStateBase interface and stores a reference (place in memory) for a variable that holds State classes
	private IStateBase activeState;

	private static StateManager managerInstanceRef;

	//Preventing destroying the object on load or creating copies when calling other scenes
	void Awake()
	{
		if (managerInstanceRef == null)
		{
			managerInstanceRef = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			DestroyImmediate(gameObject);
	}

	void Start () 
	{
		//we start the game by calling the BeginState() constructor
		//this is the syntax for calling a constructor.
		//the "this" is sending a reference to this object - StateManager that the States use to update managerRef
		activeState = new BeginState (this);

		//Debugging if the type is correct for activeState
		Debug.Log ("What's the type of activeState? " + activeState);
	
	}
	
	void Update () 
	{
		if (activeState != null)
			activeState.StateUpdate();
	}



	void OnGUI()
	{
		if (activeState != null)
			activeState.ShowIt();
	}



	public void SwitchState(IStateBase newState)
	{

		activeState = newState;
	}
}
