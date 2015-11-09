using UnityEngine;
using System.Collections;

public class PivotBehaviour : MonoBehaviour {
	
	float horizontal;
	float vertical;
	float direction = 0;
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
		print ("Horizontal:" + horizontal + " Vertical:" + vertical + " Direction:" + direction + " Angle:" + angle + "H:" + Input.GetAxisRaw ("Horizontal") + "V:" + Input.GetAxisRaw ("Vertical"));
	}
	
	bool isMoving(){
		if (Input.GetKey (KeyCode.LeftArrow)){
		    direction = 180;
			return true;
		} else if (Input.GetKey (KeyCode.RightArrow)){
			direction = (Input.GetAxisRaw ("Vertical") == -1) ? direction = 360 : direction = 0;
			return true;
		}

		return false;
	}
	
	void Update () {
		setAngle ();
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
