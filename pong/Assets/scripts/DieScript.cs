using UnityEngine;
using System.Collections;

public class DieScript : MonoBehaviour {
	public GameObject turtle;
	public Rigidbody2D TurtleBody;
	public float x;
	public float y;
	public float terminalVelocity=1;
		Vector2 startVector; 
	Vector2 startVelocities= new Vector2 (0,0);
	bool TimeToDie = false;
	public float DieVelocity=2;
	// Use this for initialization
	void Start () {
		TurtleBody = GetComponent<Rigidbody2D> ();
		x = turtle.transform.position.x;
		y = turtle.transform.position.y;
		startVector = new Vector2 (x, y);
	}
	public bool colliding;
	public float dieDelay=1;
	public float currentDelay=0;
	// Update is called once per frame
	void Update () {


		if (!colliding) {
			currentDelay += Time.deltaTime;
		} else if (colliding) {
			currentDelay=0;
		}
		if (currentDelay > dieDelay) {
			TimeToDie=true;
		}
		if (TurtleBody.velocity.y > terminalVelocity|| TurtleBody.velocity.y*-1>terminalVelocity ) {
			TimeToDie=true;
		}
		if (TimeToDie== true) {
			die();
			TimeToDie= false;
		}



	}
	void OnCollisionEnter2D(Collision2D collision) 
	{
		colliding = true;
		//if (collision.relativeVelocity.magnitude > DieVelocity) {
		//	TimeToDie= true;
		//}
	}
	
	void OnCollisionExit2D(Collision2D collision) 
	{
		colliding = false;
	}
	void die()
	{
		turtle.transform.position = startVector;
		TurtleBody.velocity = startVelocities;
		currentDelay = 0;
		TurtleMoveScript turtleMovescript = gameObject.GetComponent<TurtleMoveScript>();
		turtleMovescript.i = 1;

	}
}
