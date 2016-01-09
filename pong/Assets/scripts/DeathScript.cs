using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {
	private bool inRange = true;//This is whether the turtle is within the range of the level
	public float OutOfRangeTime=0;//This is how long the turtle is out of the level range
	public float Timer=1;//Time that the turtle is allowed out of range before it dies
	private Vector2 StartVector;//This is the turtle's original vector so when the turtle dies/restarts, the turtle goes back to the start vector
	private Rigidbody2D TurtleBody;
	private TurtleMovementScript TurtleMoveScr;
	private setSortingLayer setSortLayer;
	public GameObject ShaderCube;


	// Use this for initialization
	void Start () {
		StartVector = gameObject.transform.position;//sets the startVector to the starting position of the Turtle
		TurtleBody = GetComponent<Rigidbody2D> ();
		TurtleMoveScr = GetComponent<TurtleMovementScript> ();
		setSortLayer = ShaderCube.GetComponent<setSortingLayer> ();

	}
	
	// Update is called once per frame
	void Update () {
		CheckInRange ();
	}

	void OnTriggerEnter2D(Collider2D other) {//when level is in range
		
		Debug.Log (other);
		inRange = true;
		
	}
	void OnTriggerStay2D(Collider2D other) {//when level is in range
		
		Debug.Log (other);
		inRange = true;
		
	}
	void OnTriggerExit2D(Collider2D other) {//when level is out of range
		Debug.Log (other);
		inRange = false;
		
	}
	void Died()//When the turtle has died this function is called
	{
		Debug.Log ("Turtle has died");
		TurtleMoveScr.FlipGravity = 1;
		setSortLayer.sortingLayer = -100;
		TurtleBody.velocity = new Vector2 (0, 0);//Sets the velocity of the turtle to 0 so when it respawns it doesnt fly off
		gameObject.transform.position = StartVector;




	}

	void CheckInRange()//checks if the turtle is in range
	{
		if (inRange && OutOfRangeTime!=0) { //If turtle is in range and the time out of range isnt 0
			OutOfRangeTime=0;//sets the time out of range to 0;
		}
		if (! inRange) {// If not in range
			OutOfRangeTime+= Time.deltaTime;//increase how much time
			if(OutOfRangeTime> Timer)//if out of range for more than allowed time
			{
				Died();//calls the function died
			}
		}

	}
	public void Restart()
	{
		Died ();
	}

}







