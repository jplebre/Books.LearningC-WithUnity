using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class PlayStateScene1_1 : IStateBase
	{
		private StateManager manager;
		//private GameObject player;

		public PlayStateScene1_1(StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName != "Scene_1")
				Application.LoadLevel ("Scene_1");

			//player = GameObject.Find ("Player");
			manager.gameDataRef.hoverCraftPhysics.rigidbody.isKinematic = false;

			//setting the correct camera for the state
			foreach(GameObject whichCamera in manager.gameDataRef.cameras)
			{
				if (whichCamera.name != "LookAt Camera")
					whichCamera.SetActive(false);
				else
					whichCamera.SetActive(true);
			}
		}
		

		public void StateUpdate()
		{
			//did I win or loose?
			if(manager.gameDataRef.playerLives <= 0)
			{
				manager.SwitchState(new LostStateScene1(manager));
				manager.gameDataRef.ResetPlayer();
				manager.gameDataRef.hoverCraftPhysics.rigidbody.isKinematic = true;
				manager.gameDataRef.hoverCraft.transform.position = new Vector3(50, .5f, 40);
			}	

			if(manager.gameDataRef.score >= 2)
			{
				manager.SwitchState (new WonStateScene1(manager));
				manager.gameDataRef.hoverCraftPhysics.rigidbody.isKinematic = true;
				manager.gameDataRef.hoverCraft.transform.position = new Vector3(50, .5f, 40);
			}

			if (Input.GetKeyUp(KeyCode.Escape))
			{
				manager.SwitchState (new SetupState(manager));
				manager.gameDataRef.hoverCraftPhysics.rigidbody.isKinematic = true;
				manager.gameDataRef.hoverCraft.transform.position = new Vector3(50, .5f, 40);
			}	
		}

		
		public void ShowIt()
		{
			//showing the score
			GUI.Box (new Rect(10,10,100,25), string.Format ("Score: " + manager.gameDataRef.score));

			//showing lives left
			GUI.Box (new Rect(Screen.width - 110, 10, 100, 25), string.Format ("Lives left: " + manager.gameDataRef.playerLives));

			if(GUI.Button (new Rect(Screen.width/2 - 130, 10, 260, 30), string.Format ("Click here or Press 2 to change camera")) || Input.GetKeyUp(KeyCode.Alpha2))
				manager.SwitchState(new PlayStateScene1_2(manager));


		}
	}
}