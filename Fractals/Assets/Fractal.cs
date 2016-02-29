using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour {

	public Mesh [] multiMesh;
	public Material material;

	public int maxDepth;
	private int depth;

	public float childScale;

	public float respawnChance;

	public float maximumRotationSpeed;
	private float rotationSpeed;

	private void Start () {
		rotationSpeed = Random.Range (-maximumRotationSpeed, maximumRotationSpeed);
		gameObject.AddComponent<MeshFilter>().mesh = multiMesh[Random.Range(0,multiMesh.Length)];
		gameObject.AddComponent<MeshRenderer>().material = material;
		gameObject.AddComponent<Rigidbody> ().isKinematic = true;
		gameObject.AddComponent<BoxCollider>();
		if (depth < maxDepth) {
			StartCoroutine(CreateChildren());
		}
	}

	void Update(){
		transform.Rotate (0f, rotationSpeed * Time.deltaTime, 0f);
	}

	private IEnumerator CreateChildren () {
			yield return new WaitForSeconds (0.1f);
			new GameObject ("Fractal Child").
		AddComponent<Fractal> ().Initialize (this, Vector3.up, Quaternion.identity);


		if (Random.value < respawnChance) {
			yield return new WaitForSeconds (0.1f);
			new GameObject ("Fractal Child").AddComponent<Fractal> ().
		Initialize (this, Vector3.right, Quaternion.Euler (0f, 0f, -90f));
		}

		if (Random.value < respawnChance) {
			yield return new WaitForSeconds (0.1f);
			new GameObject ("Fractal Child").AddComponent<Fractal> ().
		Initialize (this, Vector3.left, Quaternion.Euler (0f, 0f, 90f));
		}

		if (Random.value < respawnChance) {
			yield return new WaitForSeconds (0.1f);
			new GameObject ("Fractal Child").AddComponent<Fractal> ().
		Initialize (this, Vector3.down, Quaternion.identity);
		}

		if (Random.value < respawnChance) {
			yield return new WaitForSeconds (0.1f);
			new GameObject ("Fractal Child").AddComponent<Fractal> ().
		Initialize (this, Vector3.forward, Quaternion.Euler (-90f, 0f, 0f));
		}

		if (Random.value < respawnChance) {
			yield return new WaitForSeconds (0.1f);
			new GameObject ("Fractal Child").AddComponent<Fractal> ().
		Initialize (this, Vector3.back, Quaternion.Euler (90f, 0f, 0f));
		}
	}

	private void Initialize (Fractal parent, Vector3 direction, Quaternion orientation) {
		multiMesh = parent.multiMesh;
		material = parent.material;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		respawnChance = parent.respawnChance;
		maximumRotationSpeed = parent.maximumRotationSpeed;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = direction * (0.5f + 0.5f * childScale);
		transform.localRotation = orientation;
	}
}