using UnityEngine;
using System.Collections;

public class TurtleMovementScript : MonoBehaviour
{

	public KeyCode RightKey;// Key which makes the turtle go right
	public KeyCode LeftKey;// Key which makes the turtle go left
	public KeyCode GravityButton; //This is the key which flips gravtiy

	public int FlipGravity = 1;//This holds 1 or -1 depending on which way gravity is acting
	
	private Rigidbody2D TurtleBody;// This is the rigidbody of the turtle

	public Vector2 SpeedVector; //Holds the current X and Y velocities of the turtle; needed as you cannot change the velocities directly

	public float MaxSpeed = 10; //This is the maximum horizontal speed the turtle can reach on its own
	public float acceleration = 1;// the acceleration of the turlte in m/s^2 if you want to base of acceleration time just write instead "acceleration= Maxspeed/accelerationTime"
	public float accelerationTime = 1;//This variable is only used to show developers how quick it takes for the turtle to reach max speed;

	public float GravityAccel = 1;// the vertical acceleration of the turtle
	public float GravityMaxSpeed=10;

	public float Xdrag=1;
	public float Ydrag=1;


	// Use this for initialization
	void Start ()
	{
		TurtleBody = GetComponent<Rigidbody2D> ();//sets the turtlebody to gameobject
		accelerationTime = MaxSpeed / acceleration;
	}
	
	// Update is called once per frame
	void Update ()
	{
		SpeedVector = TurtleBody.velocity;//this sets SpeedVector to the current velocities of the turtle
	
		Drag ();//calls the drag function
		Gravity ();//calls the gravity function
		Move ();//calls the move function


		TurtleBody.velocity = SpeedVector; //this sets the velocity of the turtle to the manipulated SpeedVector
	}

	// this is gravity
	void Gravity ()
	{
		if (Input.GetKeyDown (GravityButton)) {
			FlipGravity*=-1;//flips which way the gravity works
		}
		SpeedVector.y -= GravityAccel * Time.deltaTime*FlipGravity;//every second increases the vertical velocity by -GravityAccel
	}



	void Move ()//this function moves the Turtle Left and Right
	{
		//Discuss: have a slider to change between left and right



		if (Input.GetKey (RightKey)) {// if RightKey is pressed.. go right
			if (SpeedVector.x < MaxSpeed) {//only accelerates if maxspeed has not been reached
				SpeedVector.x += acceleration* Time.deltaTime; //every second the velocity will increase by the acceleration
				if (SpeedVector.x > MaxSpeed) {//if maxspeed has been exceeded then the velocity is set back to the max speed
					SpeedVector.x = MaxSpeed;
				}
			}
		} else if (Input.GetKey (LeftKey)) {// if LeftKey pressed go.. left
			if (SpeedVector.x > MaxSpeed * -1) {//Only accelerates if Maxspeed*-1 has not been reached
				SpeedVector.x += acceleration * -1 * Time.deltaTime; //every second the velocity will increase by the acceleration*-1
				if (SpeedVector.x < MaxSpeed * -1) {//if maxspeed*-1 has been exceeded then the velocity is set back to the max speed
					SpeedVector.x = MaxSpeed * -1;
				}
			} 
		} 
	}
	void Drag()
	{
		SpeedVector.x -= SpeedVector.x * Xdrag/100;//takes off a little bit of velocity depending on the speed
		SpeedVector.y -= SpeedVector.y * Ydrag/100;
	}
}









