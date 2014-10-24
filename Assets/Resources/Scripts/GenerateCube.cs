using UnityEngine;
using System.Collections;

public class GenerateCube : MonoBehaviour {
	public GameObject prototype;

	private GameObject[,] cubes;
	private int[,] recorded_heightfield;


	void Start () {
		// Disable to avoid showing the cubes populating
		this.enabled = false;

		// Create a set of cube objects from the prototype
		cubes = new GameObject[10, 10];
		int[,] heightfield = generateHeightfield ();

		for (int x = 0; x < cubes.GetLength(0); x++){
			for (int z = 0; z < cubes.GetLength(1); z++){
				cubes[x, z] = (GameObject) GameObject.Instantiate(prototype, new Vector3(x, heightfield[x, z], z), Quaternion.identity);
				cubes[x, z].transform.SetParent(this.transform);
			}
		}
		
		// Reenable to display
		this.enabled = true;
	}
	
	// Creates a new heightfield and records it
	void memorizeField() { recorded_heightfield = generateHeightfield (); }
	// Applies a recorded heightfield
	void remember() { applyHeightfield (recorded_heightfield); }

	/// <summary> Creates a new heightfield, a 2D array of random integer heights </summary>
	/// <returns> A 2D array of integer heights. </returns>
	int[,] generateHeightfield() {
		int[,] heightfield = new int[cubes.GetLength(0), cubes.GetLength(1)];

		for (int x = 0; x < cubes.GetLength(0); x++){
			for (int z = 0; z < cubes.GetLength(1); z++){
				heightfield[x, z] = Random.Range(0, Mathf.Min(cubes.GetLength(0), cubes.GetLength(1)));
			}
		}

		return heightfield;
	}

	/// <summary> Moves the cubes to the heights in the given heightfield. </summary>
	/// <param name="heightfield"> A 2D array of integer heights. </param>
	void applyHeightfield(int[,] heightfield) {
		for (int x = 0; x < cubes.GetLength(0); x++){
			for (int z = 0; z < cubes.GetLength(1); z++){
				cubes[x, z].transform.position = new Vector3(x, heightfield[x, z], z);
			}
		}
	}

}
