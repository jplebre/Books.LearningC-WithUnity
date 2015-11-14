using UnityEngine;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class BeginState : IStateBase
	{
		private StateManager manager;

		//variables for the BeginState menu screen duration
		private float futureTime = 0;
		private int countDown = 0;
		private float screenDuration = 8;

		//We initialize a constructor
		//Special method that does not have return type
		//Serves same purpose as Start()/Update(): to initialize member variables
		public BeginState (StateManager managerRef) //inputs variable managerRef of type StateManager into the constructor
		{
			manager = managerRef;

			//Testing if the right state is being called by StateManager
			Debug.Log ("Constructing BeginState");

			//starting the timer
			futureTime = screenDuration + Time.realtimeSinceStartup;

		}
		
		public void StateUpdate()
		{
			//timer function. When reaches 0, triggers if statement
			float rightNow = Time.realtimeSinceStartup;
			countDown = (int)futureTime - (int)rightNow;


			//If Key pressed, or counter reaches 0, call function to switch state

			if(Input.GetKeyUp (KeyCode.Space) || countDown <= 0)
				Switch();



		}

		public void ShowIt()
		{
			if (GUI.Button(new Rect(10,10,150,100), "Press to Play!"))
			{
				Switch();
			}

			GUI.Box (new Rect(Screen.width - 60,10,50,25), countDown.ToString ());
		}

		void Switch()
		{
			//Remember the new State needs its construct initiated
			//We are also passing to the new State who's the StateManager
			Application.LoadLevel ("Chapter08_B02");
			manager.SwitchState(new PlayState(manager));
		}

		public void StateFixedUpdate()
		{

		}
			
	}
}

