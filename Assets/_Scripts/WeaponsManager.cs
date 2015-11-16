using UnityEngine;
using System.Collections;

public class WeaponsManager : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player")
			//Instantiate(SUPER MEGA BLASTER HYPER FREE PARTICLES);
			//Funçao que determina qual arma
			//Funçao que muda as preferencias do player para a arma da box ae
			Destroy (gameObject);
	}

	//void weapon
}