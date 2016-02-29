using UnityEngine;
using System.Collections;

public class DestroyByTime: MonoBehaviour {

	public float timer = 5;

	void FixedUpdate () {
		Destroy(gameObject , timer);
	}
}