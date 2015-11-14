using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class LostStateScene1 : IStateBase
	{
		private StateManager manager;


		public LostStateScene1(StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName != "Scene_0")
				Application.LoadLevel("Scene_0");
		}

		
		public void StateUpdate()
		{
		}

		
		public void ShowIt()
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), manager.gameDataRef.wonStateSplash, ScaleMode.StretchToFill);
			
			if (GUI.Button (new Rect(10, 10, 270, 30), "Click here or press Space to repeat level") || Input.GetKeyUp(KeyCode.Space))
				manager.SwitchState(new PlayStateScene1_1(manager));

			if (GUI.Button (new Rect(10, 60, 270, 30), "Click here or press Return to quit to Menu") || Input.GetKeyUp(KeyCode.Return))
				manager.Restart();
		}
	}
}