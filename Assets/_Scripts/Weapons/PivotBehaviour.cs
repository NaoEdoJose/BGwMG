using UnityEngine;
using System.Collections;

public class PivotBehaviour : MonoBehaviour {
	
	float horizontal;
	float vertical;
	[HideInInspector]
	public float direction = 0;
	float angle;
	
	void setAngle () {
		
		bool moving = isMoving ();
		
		if (moving) {
			horizontal = (Input.GetAxisRaw ("Horizontal") == -1) ? horizontal = 180 : (Input.GetAxisRaw ("Vertical") == -1) ? horizontal = 360 : horizontal = 0;
			vertical = (Input.GetAxisRaw ("Vertical") == 1) ? vertical = 90 : (Input.GetAxisRaw ("Vertical") == -1) ? vertical = 270 : vertical = horizontal;
			direction = horizontal;

		} else {
			vertical = (Input.GetAxisRaw ("Vertical") == 1) ? vertical = 90 : (Input.GetAxisRaw ("Vertical") == -1) ? vertical = 270 : vertical = horizontal;
			horizontal = (Input.GetAxisRaw ("Vertical") == 0) ? horizontal = direction : horizontal = vertical;
		}

		angle = (horizontal + vertical) / 2;
	}
	
	bool isMoving(){
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))
			return true;
		return false;
	}
	
	void Update () {
		setAngle ();
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
