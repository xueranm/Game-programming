﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController2 : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.
	public Text countText;          //Store a reference to the UI Text component which will display the number of pickups collected.
	public GameObject sound;
	public Text livesText;
	public GameObject pickParticle;

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private int count;              //Integer to store the number of pickups collected so far.
	private int lives;

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

		//Initialize count to zero.
		count = 0;

		//Initialize lives to 3
		lives = 3;


		//Call our SetCountText 	function which will update the text with the current value for count.
		SetCountText ();

		sound.GetComponent<AudioSource>().Pause();
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement * speed);
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")) {

			Instantiate(pickParticle,other.transform.position,other.transform.rotation);

			//... then set the other object we just collided with to inactive.
			sound.GetComponent<AudioSource>().Play();
			other.gameObject.SetActive (false);
			//Add one to the current value of our count variable.
			count = count + 1;
		}

		if (other.gameObject.CompareTag ("BlackHole")) {
			lives = lives - 1;
		}

		//Update the currently displayed count by calling the SetCountText function.
		SetCountText ();
	}

	//void OnTriggerExit2D(Collider2D other){
	//	if (other.gameObject.CompareTag ("PickUp")) {
	//		audio.GetComponent<AudioSource>().Pause();
	//	}
	//}

	//This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
	void SetCountText()
	{
		//Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.

		countText.text = "Count: " + count.ToString ();
		livesText.text = "Lives left: " + lives.ToString ();
		//Check if we've collected all 12 pickups. If we have...
		if (count >= 12) {

			SceneManager.LoadScene("Level3");
		}

		if (lives <= 0) {
			SceneManager.LoadScene("Gameover");
		}
	}
}