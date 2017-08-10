using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

	public GameObject flame;

	void Start () 
	{
		flame.SetActive (false);
	}

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.gameObject.CompareTag ("Player"))
		    flame.SetActive (true);
	}

	// Update is called once per frame
	//void OnTriggerExit2D (Collider2D other) 
	//{
	//	flame.SetActive (false);
	//}
}
