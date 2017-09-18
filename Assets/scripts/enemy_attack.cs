using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour {

	public float maxDistance;
	public float coolDownTimer;
	public player_health ph;
	public int damage_level;

	private Transform myTransform;
	public Transform target;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		myTransform = transform;
		maxDistance = 3;
		coolDownTimer = 0;
		damage_level = -10;

		ph = (player_health) go.GetComponent(typeof(player_health));
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(target.position, myTransform.position);
		if(distance < maxDistance){
			Attack();
		}
		if(coolDownTimer > 0){
			coolDownTimer = coolDownTimer - Time.deltaTime;
		}

		if(coolDownTimer < 0){
			coolDownTimer = 0;
		}
	}

	void Attack(){
		Vector3 dir = Vector3.Normalize(target.position - myTransform.position);
		float direction = Vector3.Dot (dir, transform.forward);

		if(direction > 0){
			if(coolDownTimer == 0){
				ph.ChangeHealth(damage_level);
				coolDownTimer = 1;
			}
		}
		if(coolDownTimer == 0){
			ph.ChangeHealth(damage_level);
			coolDownTimer = 1;
		}		
	}

}
