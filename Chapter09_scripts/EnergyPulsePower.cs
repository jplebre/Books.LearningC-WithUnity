using UnityEngine;
using System.Collections;

public class EnergyPulsePower : MonoBehaviour 
{
	public float pulseDuration = 1f;
	public Transform goodOrb;

	
	void Update () 
	{
		pulseDuration -= Time.deltaTime;
		if(pulseDuration <= 0)
			Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "BadOrb")
		{
			Instantiate (goodOrb, other.transform.position, transform.rotation);
			GameObject.Find ("GameManager").GetComponent<GameData>().playerLives += 1;
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		else
			Destroy (gameObject);
	}
}
