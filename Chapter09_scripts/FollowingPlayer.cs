using UnityEngine;
using System.Collections;

public class FollowingPlayer : MonoBehaviour {

	public float cameraHeight = 0.5f;
	public float cameraDistance = 0.5f;

	private Transform playerPosition;

	void Start()
	{
		playerPosition = GameObject.Find ("HoverCraft").transform;
	}

	void LateUpdate()
	{
		transform.position = playerPosition.position + new Vector3(-cameraDistance, cameraHeight, cameraDistance);
		transform.LookAt(playerPosition);
	}
}
