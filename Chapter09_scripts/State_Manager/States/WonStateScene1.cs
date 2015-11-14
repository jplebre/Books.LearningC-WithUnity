using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class WonStateScene1 : IStateBase
	{
		private StateManager manager;

		public WonStateScene1(StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName != "Scene_0")
				Application.LoadLevel("Scene_0");

			manager.gameDataRef.SetScore();
		}

		
		public void StateUpdate()
		{
		}
		
		public void ShowIt()
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), manager.gameDataRef.wonStateSplash, ScaleMode.StretchToFill);

			if (GUI.Button (new Rect(10, 10, 250, 250), "Click here or press Space for next level") || Input.GetKeyUp(KeyCode.Space))
				manager.SwitchState(new PlayStateScene2(manager));
			
		}
		
	}
}