using UnityEngine;
using System.Collections;
using Assets.Scripts.State_Manager.Interfaces;

namespace Assets.Scripts.State_Manager.States
{
	public class LostStateScene2 : IStateBase
	{
		private StateManager manager;

		public LostStateScene2(StateManager managerRef)
		{
			manager = managerRef;
			if (Application.loadedLevelName != "Scene_0")
				Application.LoadLevel("Scene_0");
		}

		
		public void StateUpdate()
		{
			if (Input.GetKeyUp (KeyCode.Space))
				manager.SwitchState (new PlayStateScene2(manager));
			if (Input.GetKeyUp (KeyCode.Return))
				manager.Restart();
		}
		
		public void ShowIt()
		{
			Debug.Log ("Game is in LostStateCene2");
		}
	}
}