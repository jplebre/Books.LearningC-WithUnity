using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class SetupState : IStateBase
	{
		private StateManager manager;

		private GameObject player;
		private PlayerControl controller;

		public SetupState(StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName !=  "Scene_0")
				Application.LoadLevel("Scene_0");

			player = GameObject.Find ("HoverCraft");
			controller = player.GetComponent<PlayerControl>();
		}


		public void StateUpdate()
		{
			//GetButton is defined in Edit>ProjectSettings>Input
			//When not jumping, we are spinning!
			if(!Input.GetButton("Jump"))
				controller.transform.Rotate(0, 0, controller.spinSpeed*Time.deltaTime);
		}


		public void ShowIt()
		{
			//Creates the menu with the selection of the colour
			//If player presses any of the boxes, it calls the PlayerControl PickedColor Function
			GUI.Box(new Rect(10,10,100,180), "Player Color");
			if (GUI.Button (new Rect(20,40,80,20), "Red"))
				controller.PickedColor(controller.red);
			if (GUI.Button (new Rect(20,70,80,20), "Blue"))
				controller.PickedColor(controller.blue);
			if (GUI.Button (new Rect(20,100,80,20), "Green"))
				controller.PickedColor(controller.green);
			if (GUI.Button (new Rect(20,130,80,20), "Yellow"))
				controller.PickedColor(controller.yellow);
			if (GUI.Button (new Rect(20,160,80,20), "White"))
				controller.PickedColor(controller.white);

			//following code displays information
			GUI.Label (new Rect(Screen.width/2-95, Screen.height-100, 190, 30), "Hold 'SpaceBar' to Stop Rotation");
			GUI.Box(new Rect(Screen.width -110,10,100,25), string.Format ("Lives Left: " + manager.gameDataRef.playerLives));

			//setting up difficulty
			GUI.Box (new Rect(Screen.width -110, 40, 100, 120), "Difficulty");
			if(GUI.Button (new Rect(Screen.width-100, 70, 80, 20), "Hard"))
				manager.gameDataRef.SetPlayerLives(5);
			if(GUI.Button (new Rect(Screen.width-100, 100, 80, 20), "Normal"))
				manager.gameDataRef.SetPlayerLives(10);
			if(GUI.Button (new Rect(Screen.width-100, 130, 80, 20), "Can't Loose"))
				manager.gameDataRef.SetPlayerLives (1000);


			if(GUI.Button (new Rect(Screen.width/2-100, Screen.height-50, 200, 40),"Click Here or Press 'P' to Play") || Input.GetKeyUp(KeyCode.P))
			{
				manager.SwitchState (new PlayStateScene1_1 (manager));
				player.transform.position = new Vector3(50, .5f, 40);
			}
				

		}
	}
}