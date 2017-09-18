using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    private Rigidbody rb;
    private float speed;
    private int coin_count;
    private int cube_count;
    public Text countText;
    public Text wintext;

	// Use this for initialization
	void Start () {
        speed = 10;
        rb = GetComponent<Rigidbody>();
        coin_count = 0;
        cube_count = 0;        
        SetCountText();
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup_coins"))
        {
            other.gameObject.SetActive(false);
            coin_count += 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Pickup_cubes"))
        {
            other.gameObject.SetActive(false);
            cube_count += 1;
            SetCountText();
        }
        //Destroy(other.gameObject);
    }

    void SetCountText()
    {
        countText.text = "Cubes Collected : " + cube_count.ToString() +"/10" + "\nCoins Collected: " + coin_count.ToString() + "/7";
        if(cube_count+coin_count == 17)
        {
            wintext.text = "You Win!!!\nYou have collected all the objects";
        }
    }
}
