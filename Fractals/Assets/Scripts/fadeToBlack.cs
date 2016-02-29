using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fadeToBlack : MonoBehaviour
{

	public Canvas blank;

	public bool theBool = false;

	void Start(){
		blank.enabled = false;
	}

	void Update(){

		if (theBool == true) {
			//newScene ();
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "FPSController") {
			blank.enabled = true;
			StartCoroutine(newScene());
		}
	}

	private IEnumerator newScene () {
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}
}