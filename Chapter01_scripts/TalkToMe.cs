/* Used as an example for Dot Syntax.
 * Learning script will be calling variables and methods from this script
 */


using UnityEngine;
using System.Collections;

public class TalkToMe : MonoBehaviour {

	public string theVariable = "This is the TalkToMe variable";

	public void MakeMeTalk()
	{
		Debug.Log ("This is the TalkToMe method");
	}
}
