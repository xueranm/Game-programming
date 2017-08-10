using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

	public void Quit (){
		Debug.Log ("APPLICATION QUIT!");
		Application.Quit ();
	}

	public void Retry1(){
		SceneManager.LoadScene("Level1");
	}

	public void Retry2(){
		SceneManager.LoadScene("Level2");
	}

	public void Retry3(){
		SceneManager.LoadScene("Level3");
	}
}
