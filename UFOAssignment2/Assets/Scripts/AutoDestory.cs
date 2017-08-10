using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestory : MonoBehaviour {

	public float destroryTime = 5.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroryTime);
	}

}
