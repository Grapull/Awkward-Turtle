using UnityEngine;
using System.Collections;
//create turtle autoload game;



public class TurtleMoveScript : MonoBehaviour {

	private Rigidbody2D TurtleBody;
	public GameObject Turtlesemi;
	public GameObject start;
	public Vector2 SpawnVector;
	// Use this for initialization
	void Start () 
	{

		SpawnVector = new Vector2 (start.transform.position.x, (start.transform.position.y + 1));
		TurtleBody = GetComponent<Rigidbody2D> ();


		TurtleBody.position = SpawnVector;


		//Physics2D.IgnoreCollision (GetComponent<Collider2D> (), Turtlesemi.GetComponent<Collider2D> ());
	}
	public KeyCode LeftKey; // this is to move turtle left
	public KeyCode RightKey;// this is to move turtle right
	public KeyCode SwitchGravity;
	public float speed= 10;
	public float deceleration= 1;


	public Vector2 moveSpeed;
	public float gravity=10;
	public float termialVelocity= 56;
	public float muchVel= 0.5f;
	public bool colliding;
	 float howMuchVel=1;

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
		colliding = true;// remove this line if you want no movement in mid air;


			if (Input.GetKey (RightKey)&&colliding) {
				
				moveSpeed = new Vector2 ((TurtleBody.velocity.x + 1 * howMuchVel), TurtleBody.velocity.y);
				if (moveSpeed.x > speed) {
					moveSpeed.x = speed;
				}

			} else if (Input.GetKey (LeftKey)&&colliding) {
				
				moveSpeed = new Vector2 ((TurtleBody.velocity.x + 1* -1 * howMuchVel), TurtleBody.velocity.y);
				if (moveSpeed.x < speed * -1) {
					moveSpeed.x = speed * -1;
				}
			}
		
		else 
		{
			moveSpeed= new Vector2(TurtleBody.velocity.x/deceleration,TurtleBody.velocity.y);

		}
	}
	public int i=1;
	Vector2 minusSpeed= new Vector2(0,0);
	void Gravity()
	{ 

		if (Input.GetKeyDown(SwitchGravity) /*&& colliding*/) {
			i*=-1;
		}
		minusSpeed = new Vector2 (0, (gravity * 10 * Time.deltaTime * i)); 
	

		moveSpeed -= minusSpeed;


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



}
