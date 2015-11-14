using UnityEngine;
using System.Collections;

public class LearningScript : MonoBehaviour 
{
	//variables used for the AddTwoNumbers() method
	public int number1 = 2;
	public int number2 = 9;
	public int number3 = 11;

	//now, variables for the Dot Syntax examples
	//Let's start by creating a variable, otherComponent, that will store a value of type TalkToMe
	TalkToMe otherComponent;

	//For Dot Syntax examples, communicating between different objects
	GameObject cubeLeftGo; //for example one, see Start()
	Spinner cubeRightGo; //for example two, see Start()


	void Start () 
	{
		// this first bit is for the method initialization and call examples
		int answer = 
		AddTwoNumbers (number1, number2) +
		AddTwoNumbers (number2, number3) +
		AddTwoNumbers (number3, number1); //note that int answer's statement is 4 lines long!
		DisplayResult (answer);

		//This bit is for the Dot Syntax examples
		Debug.Log ("for the Dot Syntax example, press the return key");
		otherComponent = GetComponent<TalkToMe> (); //assigns the instance of component TalkToMe on this GameObject to otherComponent

		//This bit of code is for Dot Syntax, talking with other GameObjects
		//It works in conjunction with the Spinner script
		Debug.Log ("Use left/right arrow keys to rotate each of the onjects");
		cubeLeftGo = GameObject.Find ("Cube Left"); //example one: initialize a GameObject variable. You will have to then GetComponent on this variable
		cubeRightGo = GameObject.Find ("Cube Right").GetComponent<Spinner>(); //example two: initialized as a class, it still needs to find the Game Object
																	 	   //but because cubeRightGo is a class type, we cannot initialise to a GameObject. We had to get it's Script/class

	}
	
	void Update () 
	{
		//Code for the first Dot Syntax example
		if (Input.GetKeyUp (KeyCode.Return)) 
		{
			Debug.Log ("This is the TalkToMe Component: " + otherComponent);//will return the name of the GameObject and the name of the component
			Debug.Log (otherComponent.theVariable); // will return the variable in GameObject
			Debug.Log (GetComponent<TalkToMe>().theVariable); //exactly the same as above
			otherComponent.MakeMeTalk (); //will perform action of method MakeMeTalk(), which is set to print to console a string
		}

		//Code for the second Dot Syntax example - Spinner
		if (Input.GetKey (KeyCode.LeftArrow)) 
		    cubeLeftGo.GetComponent <Spinner>().SpinLeft(); //because cubeLeftGo is a variable of a gameobject, we still need to get it's component/script/class to call the method
		if (Input.GetKey (KeyCode.RightArrow))
			cubeRightGo.SpinRight (); //because cubeRightGo is a variable with GameObject's script, we only need to call it's method


	}

	//Methods used to demonstrate how to initialize and call function
	int AddTwoNumbers(int firstNumber, int secondNumber)
	{
		int result = firstNumber + secondNumber;
		return result;
	}

	void DisplayResult(int total)
	{
		Debug.Log ("The Grand Total is: " + total);
	}



}
