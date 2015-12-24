using UnityEngine;
using System.Collections;

public class CameraTurtleTrack : MonoBehaviour {
	public GameObject cameraToMove;
	private Camera cam;
	public GameObject Turtle;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();

	}	
	
	// Update is called once per frame
	void Update () {
		cameraToMove.transform.position = Turtle.transform.position - new Vector3 (0, 0, 10);
	}
}
