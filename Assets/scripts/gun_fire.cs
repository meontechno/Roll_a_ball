using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_fire : MonoBehaviour {

	private AudioSource ads;
	private Animation anim;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			ads = GetComponent<AudioSource>();
			anim = GetComponent<Animation>();
			ads.Play();
			anim.Play();
		}
	}
}
