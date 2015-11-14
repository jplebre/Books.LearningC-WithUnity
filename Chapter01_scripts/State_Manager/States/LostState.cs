using UnityEngine;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class LostState : IStateBase
	{
		private StateManager manager;
		
		//We initialize a constructor
		//Special method that does not have return type
		//Serves same purpose as Start()/Update(): to initialize member variables
		public LostState (StateManager managerRef) //inputs variable managerRef of type StateManager into the constructor
		{
			manager = managerRef;
			Debug.Log ("Constructing LostState");
		}
		
		public void StateUpdate()
		{
			//If Key pressed, change state
			//Remember the new State needs its construct initiated
			//We are also passing to the new State who's the StateManager
			if (Input.GetKeyUp(KeyCode.Space))
				Application.LoadLevel("Chapter08_B01");
				manager.SwitchState(new BeginState(manager));
			
		}
		
		public void ShowIt()
		{
			
		}
		
		public void StateFixedUpdate()
		{
			
		}
		
	}
}

