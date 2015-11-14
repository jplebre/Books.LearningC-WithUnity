using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
	public void SpinLeft()
	{
		//rotate 0 degrees on x, 0 degrees on Y, 60 degrees on Z, for each second passed)
		//we are using transform class (transform component linked with game Object)
		//this class includes a method - Rotate(x,y,z,time), which we are calling
		transform.Rotate(0,0,60 * Time.deltaTime);
	}

	public void SpinRight()
	{
		//rotate 0 degrees on x, 0 degrees on Y, -60 degrees on Z, for each second passed)
		transform.Rotate(0,0,-60 * Time.deltaTime);
	}


	//we could say the entire address of the call is GameObject.Find("Cube Left").GetComponent<Spinner>().transform.Rotate(0,0,60*Time.deltaTime);                                                    
}
