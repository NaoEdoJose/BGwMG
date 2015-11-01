﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask notToHit;

	float timeToFire = 0 ;
	Transform firePoint;


	void Awake () {

		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError("No FirePoint , Stupid");
		}

	}

	void Update () {
	
		if (fireRate == 0) {
			if (Input.GetKeyDown (KeyCode.X)) {
				Shoot ();
			}
		} else {
			if(Input.GetKey(KeyCode.X) && Time.time > timeToFire){

				timeToFire = Time.time + 1/fireRate;
				Shoot();

			}
		
		}
	}
	void Shoot(){
		Debug.Log("Working!");

	}

}
