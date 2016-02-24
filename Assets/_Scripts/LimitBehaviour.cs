using UnityEngine;
using System.Collections;

public class LimitBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			Debug.Log ("1");
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
