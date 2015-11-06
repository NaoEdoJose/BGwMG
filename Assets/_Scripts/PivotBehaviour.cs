using UnityEngine;
using System.Collections;

public class PivotBehaviour : MonoBehaviour {

	float horizontal;
	float vertical;
		
	void setTo () {
		horizontal = Input.GetAxisRaw ("Horizontal") < 0 ? horizontal = 180 : horizontal = 0;
		vertical = Input.GetAxisRaw ("Vertical") * 90; 
	}

	void Update () {
		setTo ();
		transform.rotation = Quaternion.Euler(0, 0, vertical);
	}
}
