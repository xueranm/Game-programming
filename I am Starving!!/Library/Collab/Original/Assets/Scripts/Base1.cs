using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Base1 : MonoBehaviour {
	private int count;
    public Text countText;
    public Text winText;
	public Transform nextMenu;
	public Transform pauseMenu;
	private List<GameObject> insideFood; 
	
	void Start () {
		count = 0;
        countText.text = "RED: " + count.ToString()+"/5";
        winText.text = "";
		insideFood = new List<GameObject>();
    }
	
	public void buttonShowUp(bool done){
		if(done){
			nextMenu.gameObject.SetActive(true);
		}
	}
	
	public void hidePause(bool done){
		if(done){
			pauseMenu.gameObject.SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Food")) {
			insideFood.Add (other.gameObject);
			count += 1;
			other.enabled = false;
            countText.text = "RED: " + count.ToString();
        }
		if (other.gameObject.CompareTag ("Bomb")) {
			count = count -2;
			if (insideFood.Count>= 2) {
				
			}
			other.enabled = false;
			countText.text = "RED: " + count.ToString() + " Bomb explosion!";
		}
        if(count >= 5)
        {
            winText.text = "Red Wins";
			if(Time.timeScale == 1){
				Time.timeScale = 0;
				buttonShowUp(true);
				hidePause(true);
			}
        }
	}
}
