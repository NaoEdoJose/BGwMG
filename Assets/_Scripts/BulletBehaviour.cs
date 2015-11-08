using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class BulletBehaviour : MonoBehaviour {

	public float speed = 0.2f;

	float trueSpeed;
	Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player_1").GetComponent<Player> ();
	}

	void bulletDirection(ref Vector3 velocity){



	}

	// Update is called once per frame
	void Update () {
		//trueSpeed = Mathf.Sign (player.velocity.x) * speed;
		transform.Translate ( speed, 0, 0);

	}
}
