using UnityEngine;
using System.Collections;

public class shaderMove : MonoBehaviour {
	public KeyCode SwitchGravityButton;
	public float FlipGravity;
	public GameObject invertCube;
	private Renderer render;

	public int sortingLayer=-2;
	// Use this for initialization
	void Start () {
		render= GetComponent<Renderer> ();
		if (render) {
			render.sortingOrder= sortingLayer;
		}
	}
	int i2=-2;

	// Update is called once per frame
	void Update () {
		GameObject turtle = GameObject.Find( "Turtle(collider)");
		invertCube.transform.position = new Vector3 (turtle.transform.position.x, turtle.transform.position.y,invertCube.transform.position.z);
		TurtleMoveScript turtleMoveScript = turtle.GetComponent<TurtleMoveScript> ();
		int i = turtleMoveScript.i;
		if (i != i2) {

			render.sortingOrder*= -1;

		}


		i2 = i;
	}
}
