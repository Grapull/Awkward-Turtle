using UnityEngine;
using System.Collections;

public class ReferenceScript : MonoBehaviour {
	//This is an experiment script. It's Purpose is that you dont need to keep referencing other scripts, Just this one;
	// Use this for initialization
	public GameObject Turtle;
	public GameObject Cam;
	public GameObject ShaderCube;
	private CameraMoveScript cameraMoveScript;
	private DeathScript deathScript;
	private rotateSemi rotatesemi;
	private setSortingLayer setsortingLayer;
	private TurtleMovementScript turtleMovementScript;

	void Start () {
		cameraMoveScript = Cam.GetComponent<CameraMoveScript> ();
		deathScript = Turtle.GetComponent<DeathScript> ();
		rotatesemi = Turtle.GetComponent<rotateSemi> ();
		setsortingLayer = ShaderCube.GetComponent<setSortingLayer> ();
		turtleMovementScript = Turtle.GetComponent<TurtleMovementScript> ();
	}
	
	// Update is called once per frame
}
