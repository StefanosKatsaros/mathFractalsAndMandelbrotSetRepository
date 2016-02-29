using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce = 1000f;
	public float moveSpeed = 10f;

	public bool holdFire = true;

	public GameObject gunLight;
	public Material materialBlue;
	public Material materialRed;

	void FixedUpdate ()
	{
		if(Input.GetButtonUp("Fire1") && holdFire == true)
		{	
			StartCoroutine(Fire());
			holdFire = false;
		}
	}

	private IEnumerator Fire () {


		Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
		shot.AddForce(shotPos.forward * shotForce);
		gunLight.GetComponent<MeshRenderer>().material = materialRed;
		yield return new WaitForSeconds(1.0f);
		holdFire = true;
		gunLight.GetComponent<MeshRenderer>().material = materialBlue;

	}

}