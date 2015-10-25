using UnityEngine;
using System.Collections;

public class DieScript : MonoBehaviour {


	public GameObject turtle;
	public Rigidbody2D TurtleBody;
	public float x;
	public float y;
	public float terminalVelocity=1;
	public Vector2 startVector = new Vector2 (-30, 5);
	Vector2 startVelocities= new Vector2 (0,0);
	bool TimeToDie = false;
	public float DieVelocity=2;
	// Use this for initialization
	void Start () {
		TurtleBody = GetComponent<Rigidbody2D> ();
		x = turtle.transform.position.x;
		y = turtle.transform.position.y;

	}
	public bool colliding;
	public bool inRange;
	public float dieDelay=1;
	public float RangeDieDelay=1;
	private float currentDelay=0;
	private float InRangeDelay=0;
	// Update is called once per frame
	void Update () {

		if (inRange) {
			InRangeDelay=0;
		}
		if (!inRange) {

			InRangeDelay += Time.deltaTime;
		}


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
		if (TimeToDie== true || InRangeDelay>RangeDieDelay) {
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

	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log (other);
		inRange = true;
		
	}
	void OnTriggerStay2D(Collider2D other) {
		
		Debug.Log (other);
		inRange = true;
		
	}
	void OnTriggerExit2D(Collider2D other) {
		Debug.Log (other);
		inRange = false;

	}

	
	
	
	
	void die()
	{
		TurtleMoveScript turtleMovescript = gameObject.GetComponent<TurtleMoveScript>();
		startVector = turtleMovescript.SpawnVector;
		turtle.transform.position = startVector;
		TurtleBody.velocity = startVelocities;
		currentDelay = 0;

		turtleMovescript.i = 1;

	}
}
