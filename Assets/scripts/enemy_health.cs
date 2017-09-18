using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_health : MonoBehaviour {

	public int current_health;
	public int max_health;
	//public float hblength;

	// Use this for initialization
	void Start () {
		current_health = 100;
		max_health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(current_health <= 0){
			Dead();
		}
	}	

	public void ChangeHealth(int health){
		current_health -= health;
	}

	void Dead() {
		this.gameObject.SetActive(false);
	}
}
