using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class BulletBehaviour : MonoBehaviour {

	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//trueSpeed = Mathf.Sign (player.velocity.x) * speed;
		transform.Translate ( speed, 0, 0);

	}
}
