using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {

	public Transform[] SpawnPoints;
	public float spawnTime = 1.5f;
	public float rates = 5.0f;

	public GameObject[] pickups;

	private List<int> randomList;
	private int spawnIndex;
	private int objectIndex;

	// Use this for initialization
	void Start () {
		randomList = new List<int> ();
		//randomList2 = new List<int> ();
		InvokeRepeating ("spawnpickups",spawnTime,rates);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnpickups()
	{
		randomList.Clear ();
		for (int i = 0; i < 4; i++) {
			spawnIndex = Random.Range (0, SpawnPoints.Length);
			while(randomList.Contains(spawnIndex)){
				spawnIndex = Random.Range (0, SpawnPoints.Length);
			}
			randomList.Add (spawnIndex);
			Instantiate (pickups[0], SpawnPoints[spawnIndex].transform.position, SpawnPoints [spawnIndex].transform.rotation);
		}
		spawnIndex = Random.Range (0, SpawnPoints.Length);
		while(randomList.Contains(spawnIndex)){
			spawnIndex = Random.Range (0, SpawnPoints.Length);
		}
		objectIndex = Random.Range (0, pickups.Length); 
		Instantiate (pickups [objectIndex], SpawnPoints [spawnIndex].transform.position, SpawnPoints [spawnIndex].transform.rotation);

	}

}
