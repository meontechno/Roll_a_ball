using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour {

	public int current_health;
	public int max_health;
	public float hblength;
	private int chest_count;
	public Text countText;
    public Text wintext;
	public AudioSource[] audio;
	private GameObject gun;

	// Use this for initialization
	void Start () {
		chest_count = 0;
		gun = GameObject.FindGameObjectWithTag("Gun");
		hblength = Screen.width /2;
		max_health = 100;
		current_health = max_health;
		audio = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		SetCountText();
		ChangeHealth(0);
	}

	void OnGUI(){
		GUI.backgroundColor = Color.red;
		GUI.Box(new Rect(10, 10, hblength, 25), "Your Health");
	}

	public void ChangeHealth(int health){
		current_health += health;
		hblength = (Screen.width / 2) * (current_health /(float)max_health);
		if(current_health <= 0){
			Dead();
		}
	}

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Chest"))
        { 
        	audio[1].Play();       	
        	chest_count +=1;
            other.gameObject.SetActive(false);
            SetCountText();
            
        }
        else if (other.gameObject.CompareTag("Pickup_cubes"))
        {
            other.gameObject.SetActive(false);

        }
        //Destroy(other.gameObject);
    }

    void SetCountText()
    {
        countText.text = "Chests Collected : " + chest_count.ToString() +"/8";
        if(chest_count == 8)
        {
            wintext.text = "You Win!!!\nYou have collected all the chests.";
        }
    }

	void Dead(){
		//torch.gameObject.SetActive(false);
		gun.gameObject.SetActive(false);
	}
}
