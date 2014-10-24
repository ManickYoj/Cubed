using UnityEngine;
using System.Collections;

public class GenerateCube : MonoBehaviour {
	public GameObject prototype;
	private GameObject[,] cubes;

	// Use this for initialization
	void Start () {
		this.enabled = false;
		cubes = new GameObject[10, 10];
		int height;

		for (int x = 0; x < cubes.GetLength(0); x++){
			for (int z = 0; z < cubes.GetLength(1); z++){
				height = Random.Range(0, cubes.GetLength(0));
				cubes[x, z] = (GameObject)GameObject.Instantiate(prototype, new Vector3(x, height, z), Quaternion.identity);
			}
		}

		this.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
