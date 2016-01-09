using UnityEngine;
using System.Collections;

public class rotateSemi : MonoBehaviour {
	public GameObject semiTurtle;
	public Rigidbody2D turtle;
	public float deceleration=1;
	public float rot;
	public float GlobalRotation;
	public float i=1;
	float i2;
	public float angularVel;
	float largestI= 13;
	public float smallVel=1;
	private int gravity=1;
	public int max;
	public int min;

	// Use this for initialization
	void Start () {
		 i2 = i;



	}



	// Update is called once per frame
	void Update () {

		TurtleMovementScript turtleMovescript = turtle.GetComponent<TurtleMovementScript>();
		gravity = turtleMovescript.FlipGravity;
		angularVel = turtle.angularVelocity;



		int whichWay;
		if (semiTurtle.transform.eulerAngles.z+turtle.angularVelocity*gravity>180) {
			whichWay=1;
		}
		else
		{
			whichWay=-1;
		}

		//Quaternion rot = semiTurtle.transform.localRotation + semiTurtle.transform.rotation;
		// this gets the difference between local and world rotation, i then need to use it to create a smooth rotation so that the turtle always wants to rotate onto its back so it dont look like its floating in mid air.
		min = 97 - (90 * gravity);
		max = 263 + (90 * gravity);
		if ((! Input.GetKey (turtleMovescript.LeftKey) && ! Input.GetKey (turtleMovescript.RightKey)) || turtle.angularVelocity < smallVel) {
			if (((semiTurtle.transform.eulerAngles.z > min && semiTurtle.transform.eulerAngles.z < max) && gravity == 1) || (((semiTurtle.transform.eulerAngles.z > min || semiTurtle.transform.eulerAngles.z < max)) && gravity == -1)) {



				semiTurtle.transform.rotation = Quaternion.Euler (0, 0, semiTurtle.transform.eulerAngles.z + i * whichWay * gravity);



			} else {
				semiTurtle.transform.rotation = Quaternion.Euler (0, 0, 90 - (90 * gravity));
			}
		}
		else{
			i=i2;
		}
		if (i < largestI) {
			i = i * deceleration;
		} else {
			i=largestI;
		}
		GlobalRotation = semiTurtle.transform.eulerAngles.z;

		//semiTurtle.transform.localRotation= Quaternion.Euler (0, 0,rot);
	}
	//void OnCollisionEnter(Collision collision) {
		//ContactPoint contact = collision.contacts [0];
		//Quaternion rot = Quaternion.FromToRotation (Vector3.up, contact.normal);
		//semiTurtle.transform.localRotation = rot;
	//}
}
