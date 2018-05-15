using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	public static GM instance = null;

	public GameObject[] blueBoulders;
	public GameObject[] redBoulders;
	public GameObject[] sandBoulders;

	public float xRange;
	public float yRange;
	public float zRange;

	private ArrayList boulderTypes = new ArrayList();

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		Setup();
	}

	public void Setup() {
		boulderTypes.Clear();

		boulderTypes.Add(blueBoulders);
		boulderTypes.Add(redBoulders);
		boulderTypes.Add(sandBoulders);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate() {
		Instantiate(getRandomBoulder(), getRandomPosition(), getRandomRotation());
	}

	// MARK: - Boulder Creation

	private GameObject getRandomBoulder() {
		int randomType = Random.Range(0, boulderTypes.Count);
		GameObject[] boulders = (GameObject[])boulderTypes[randomType];

		int randomBoulder = Random.Range(0, boulders.Length);

		return boulders[randomBoulder];
	}

	private Vector3 getRandomPosition() {
		float x = Random.Range(-xRange, xRange);
		float y = Random.Range(0, yRange);
		float z = Random.Range(-zRange, zRange);

		return new Vector3(x, y, z);
	}

	private Quaternion getRandomRotation() {
		return Quaternion.Euler(Random.value, Random.value, Random.value);
	}
}
