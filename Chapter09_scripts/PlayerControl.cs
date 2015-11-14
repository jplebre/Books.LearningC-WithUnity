using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour 
{
	public float spinSpeed = 50.0f;

	//variables for the Color of the hovercraft
	//Used in the PickedColor()
	public Color red = Color.red;
	public Color blue = Color.blue;
	public Color green = Color.green;
	public Color yellow = Color.yellow;
	public Color white = Color.white;


	//variables for the physics/control
	public float speed = 20.0f;
	public float rotationSpeed = 1.0f;
	public float hoverPower = 3.5f;
	public Rigidbody projectile;

	private GameData gameDataRef;



	void Start() 
	{
		gameDataRef = GameObject.Find ("GameManager").GetComponent<GameData>();

	}




	//If this function gets called, uses one of the variables above to apply the color
	//Color is applied to the mesh renderer component of the GameObject
	public void PickedColor (Color playerChoice)
	{
		GameObject.Find ("HoverCraft").renderer.material.color = playerChoice;
	}



	//for RigidBodys, you need to use FixedUpdate instead of Update
	void FixedUpdate()
	{
		float foreAndAft = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		gameDataRef.hoverCraftPhysics.AddRelativeForce (0, - foreAndAft, 0);
		gameDataRef.hoverCraftPhysics.AddTorque (0, rotation, 0);
	}


	void OnTriggerStay(Collider other)
	{
		gameDataRef.hoverCraftPhysics.AddForce(Vector3.up * hoverPower);
	}



	//Scoring and Lives integration
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "GoodOrb")
		{
			gameDataRef.score += 1;
			Destroy (other.gameObject);
		}
	}

	void OnCollisionEnter(Collision collidedWith)
	{
		if(collidedWith.gameObject.tag == "BadOrb")
		{
			gameDataRef.playerLives -= 1;
			Destroy(collidedWith.gameObject);
		}
	}


	//controlling the energy pulse weapon
	public void FireEnergyPulse()
	{
		Rigidbody clone;
		clone = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
		clone.transform.Translate (0, -5f, 0.5f);
		clone.velocity = transform.TransformDirection (Vector3.down*50);
	}


}
