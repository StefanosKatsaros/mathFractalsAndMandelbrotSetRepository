using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


	public Transform RootObject;
	public Transform RootObjectRotation;

	private Vector3 point;

	void Start(){
		RootObject = GameObject.Find ("FPSController").transform;
		RootObjectRotation = GameObject.Find ("Root").transform;

		point = RootObjectRotation.transform.position;
	}

	void Update() {

		//transform.RotateAround (RootObject, new Vector3 (0.0f, 1.0f, 0.0f), 20 * Time.deltaTime);
		transform.RotateAround(point, Vector3.up, 10 * Time.deltaTime);
		transform.LookAt (RootObject);
	}
}