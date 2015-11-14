using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class PlayStateScene2 : IStateBase
	{
		private StateManager manager;


		public PlayStateScene2(StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName != "Scene_2")
				Application.LoadLevel("Scene_2");
		}

		
		public void StateUpdate()
		{
			if (Input.GetKeyUp (KeyCode.Space))
				manager.SwitchState(new WonStateScene2(manager));
			if (Input.GetKeyUp (KeyCode.Return))
				manager.SwitchState(new LostStateScene2(manager));
		}


		public void ShowIt()
		{
			Debug.Log ("Game is in PlayStateScene2");
		}
		
	}
}