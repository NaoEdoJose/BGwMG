using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	[SyncVar]
	private Vector3 SyncPos;

	public Transform myTransform;
	public float lerpRate = 15;
	public Transform fps;
	public Camera cam;
	public GameObject Player_1;
	public GameObject GunPivot;

	Vector3 lastPos;


	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {

			SpawnPosition sp = GameObject.Find("SpawnPoints").GetComponent<SpawnPosition>();

			int ran = Random.Range (0 , sp.spawnPos.Length - 1);

			myTransform.position = sp.spawnPos[ran].position;
			Player_1.GetComponent<Controller2D>().enabled = true;
			Player_1.GetComponent<Player>().enabled = true;
			GunPivot.GetComponent<PivotBehaviour>().enabled = true;
			cam.enabled = true;
		}
	}
	

	void Update () {
		UpdateTransform ();
	}

	void FixedUpdate(){

		TransmitTransform ();
	}

	void UpdateTransform(){
		if (!isLocalPlayer) {
			myTransform.position = Vector3.Lerp(myTransform.position , SyncPos , Time.deltaTime * lerpRate);
		
		}
	}

	[Command]
	void Cmd_PassPosition( Vector3 pos){

		SyncPos = pos;
	}



	[ClientCallback]
	void TransmitTransform(){
		if (isLocalPlayer) {
		
			float distance = Vector3.Distance (myTransform.position, lastPos);

			if (distance > .2f) {
				Cmd_PassPosition (myTransform.position);
				lastPos = myTransform.position;
			}
	
		}
	}




}
