using UnityEngine;
using System.Collections;



public class TurtleMoveScript : MonoBehaviour {

	private Rigidbody2D TurtleBody;
	public GameObject Turtlesemi;
	// Use this for initialization
	void Start () 
	{
		TurtleBody = GetComponent<Rigidbody2D> ();
		initialXL = startAcel;
		//Physics2D.IgnoreCollision (GetComponent<Collider2D> (), Turtlesemi.GetComponent<Collider2D> ());
	}
	public KeyCode LeftKey; // this is to move turtle left
	public KeyCode RightKey;// this is to move turtle right
	public KeyCode SwitchGravity;
	public float speed= 10;
	public float deceleration= 1;
	public float acceleration = 1;
	public float startAcel=1;
	public Vector2 moveSpeed;
	bool colliding = false;
	public float gravity=10;
	public float termialVelocity= 56;
	public float muchVel= 0.5f;
	 float howMuchVel=1;
	float initialXL;
	//variables to use with gyro
		


	// Update is called once per frame
	void Update () 
	{

		if (!colliding) {
			howMuchVel=muchVel;
		} else {
			howMuchVel=1;
		}
		MoveTurtle ();
		Gravity ();




		TurtleBody.velocity= moveSpeed;
	}

	void MoveTurtle()
	{


		if (Input.GetKey (RightKey)) {
			startAcel *= acceleration;
			moveSpeed = new Vector2 ((TurtleBody.velocity.x+startAcel*howMuchVel),TurtleBody.velocity.y);
			if (moveSpeed.x>speed)
			{
				moveSpeed.x= speed;
			}

		} else if (Input.GetKey (LeftKey)) {
			startAcel *= acceleration;
			moveSpeed = new Vector2 ((TurtleBody.velocity.x+startAcel*-1*howMuchVel),TurtleBody.velocity.y);
			if (moveSpeed.x<speed*-1)
			{
				moveSpeed.x= speed*-1;
			}
		}

		else 
		{
			moveSpeed= new Vector2(TurtleBody.velocity.x/deceleration,TurtleBody.velocity.y);
			startAcel=initialXL;
		}
	}
	public int i=1;
	Vector2 minusSpeed= new Vector2(0,0);
	void Gravity()
	{ 

		if (Input.GetKeyDown(SwitchGravity)) {
			i*=-1;
		}
		minusSpeed = new Vector2 (0, (gravity * 10 * Time.deltaTime * i)); 
	

		moveSpeed -= minusSpeed;


	}



}
