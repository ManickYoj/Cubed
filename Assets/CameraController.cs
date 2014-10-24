using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {
	public float cam_dist = 20.0f;
	public float angle = 45.0f;

	private bool axis_right = false;
	private bool axis_left = false;
	private LinkedList<float[]> location_tracker = new LinkedList<float[]>();
	private LinkedListNode<float[]> current_location;

	void Update () {
		// Record when any of the input axes is pressed
		// and call the rotate method with the appropriate input.
		float input_horz = Input.GetAxisRaw ("Horizontal");
		if (input_horz > 0 && !axis_right){
			axis_right = true;
			rotateCam(true);
		} else if (input_horz < 0 && !axis_left) {
			axis_left = true;
			rotateCam(false);
		} else if (input_horz == 0 && (axis_left || axis_right)){
			axis_left = false;
			axis_right = false;
		}
	}

	/// <summary> Rotates the camera right or left by 90 degrees. </summary>
	/// <param name="right"> If true, rotates the camera right. Otherwise, rotates the camera left. </param>
	void rotateCam(bool right) {
		// TODO: Implement
	}
}
