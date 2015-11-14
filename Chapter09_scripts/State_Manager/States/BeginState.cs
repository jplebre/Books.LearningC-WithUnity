using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class BeginState : IStateBase
	{
		private StateManager manager;


		public BeginState(StateManager managerRef)
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
			//Display the splash screen
			//use full screen, use the StateManager > GameData > beginStateSplash texture, scale it to fullscreen
			GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), manager.gameDataRef.beginStateSplash, ScaleMode.StretchToFill);

			//Create a button, and if it's pressed OR any key is pressed, switch to next state
			if (GUI.Button(new Rect(Screen.width/2-125, Screen.height/2-30,250,60), "Press Any Key To Continue") || Input.anyKeyDown)
				manager.SwitchState(new SetupState(manager));
		}


	}
}
