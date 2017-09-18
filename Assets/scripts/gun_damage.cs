using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_damage : MonoBehaviour {

	public int DamageAmount = 50;
	public float TargetDistance;
	public float AllowedRange = 100;	
	public enemy_health eh;

	// Use this for initialization
	void Start () {
		
		//eh = GetComponent<enemy_health>();
		//go = Instantiate(enemyhealth) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//eh.ChangeHealth(DamageAmount);
		if(Input.GetButtonDown("Fire1")){

			RaycastHit shot;
			if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot)){
				TargetDistance = shot.distance;
				
				if(TargetDistance < AllowedRange){
					Debug.Log(shot.transform.ToString());
					if(!shot.transform.CompareTag("ground")){
						Debug.Log("you are hitting an enemy");
						Debug.Log(shot.transform.ToString());
						eh = shot.collider.GetComponent<enemy_health>();
						eh.ChangeHealth(DamageAmount);
					}
					
					//go.SendMessage("ChangeHealth", DamageAmount);
					//eh = shot.collider.GetComponent<enemy_health>();
					//shot.transform.SendMessage("ChangeHealth", DamageAmount);
					//Debug.Log(shot.transform);
					
				}
			}
		}
	}
}
