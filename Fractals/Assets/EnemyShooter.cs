using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce = 1000f;
	public float moveSpeed = 10f;

	//private bool holdFire = true;

	private float timer = 2.0f;

	void FixedUpdate ()
	{

		timer -= Time.deltaTime;	
		if (timer <= 0.0f) {
			Rigidbody shot = Instantiate (projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			shot.AddForce (shotPos.forward * shotForce);
			timer = 2.0f;
		}
	}

}
