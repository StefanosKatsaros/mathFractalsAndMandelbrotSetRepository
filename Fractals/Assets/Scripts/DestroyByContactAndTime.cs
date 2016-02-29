using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyByContactAndTime : MonoBehaviour {

	public GameObject explosion;
	public float timer = 5;
//	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
//	public Image blood;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		Destroy(gameObject , timer);	
	}

	void OnCollisionEnter(Collision col){


		Instantiate (explosion, col.transform.position, col.transform.rotation);
		Destroy (gameObject);

		if (col.gameObject.name == "FPSController") {
			GameController.health -= 20;

		//	blood.color = flashColour;
			return;
		}
			
		if (col.gameObject.name == "Root" && col.gameObject.transform.childCount != 0) {
			return;
		}

		if (col.gameObject.tag == "EnemyTag") {
			GameController.score++;
		}

		if (col.gameObject.tag == "ground") {
			return;
		}


		Destroy (col.gameObject);

	}
}
