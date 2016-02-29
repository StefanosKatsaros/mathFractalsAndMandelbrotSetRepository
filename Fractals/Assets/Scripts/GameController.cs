using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public static float health;
	public static int score;
	public Text textHealth;  
	public Text textScore; 



	// Use this for initialization
	void Start () {
		health = 100;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (health < 100) {
			health += Time.deltaTime * 2;
		}

		if (health > 100) {
			health = 100;

			Debug.Log ("fULL life");

		}

		if (health <= 0) {
			Debug.Log ("You Lost");
		}


		textHealth.text = "Score: " + score;
		textScore.text = "Health: " + Mathf.Round(health);
	}

	public void easyMode(){
		SceneManager.LoadScene ("fractalScene");
	}

	public void hardMode(){
		SceneManager.LoadScene("hardMode");
	}
}