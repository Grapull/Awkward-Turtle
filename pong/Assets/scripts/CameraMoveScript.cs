using UnityEngine;
using System.Collections;

public class CameraMoveScript : MonoBehaviour {
	public GameObject cameraToMove;
	public GameObject Turtle;
	private Camera cam;
	public float Ypos;
	// Use this for initialization
	void Start () {
		Ypos = Turtle.transform.position.y;
		cam = GetComponent<Camera> ();
		cam.orthographicSize = 4;
	}	
	
	// Update is called once per frame
	void Update () {
		cameraToMove.transform.position = 	new Vector3 (Turtle.transform.position.x,Ypos-0,-10);
	}

}
