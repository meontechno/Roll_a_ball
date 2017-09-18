using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour {

	public int rotateSpeed = 1;
	private int movementSpeed = 3;
	private int maxDistance = 80;
	public Animation anim;
	public Transform target;
	private Transform myTransform;
	public AudioSource audio; 
	public bool cue = true;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		myTransform = transform;
		audio = GetComponent<AudioSource>();
		anim = GetComponent<Animation>();
		anim.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		attackPlayer();
	}

	void attackPlayer(){
		Debug.DrawLine(myTransform.position, target.position, Color.red);	
		
		//move enemy towards player
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotateSpeed * Time.deltaTime);
		if (Vector3.Distance (target.position, myTransform.position) < maxDistance){
			myTransform.position += myTransform.forward * movementSpeed * Time.deltaTime;
			maxDistance = 1000;
			
			anim.Play();
			if(cue == true){
				audio.Play();
			}
			cue = false;
			
		}	
		
	}

}
