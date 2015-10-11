using UnityEngine;
using System.Collections;

public class CameraMoveScript : MonoBehaviour {
	public GameObject cameraToMove;
	public GameObject Turtle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cameraToMove.transform.position = Turtle.transform.position- new Vector3(0,0,10);
	}
}
