using UnityEngine;
using System.Collections;

public class RotateTurtleSpriteScript : MonoBehaviour
{
	public GameObject TurtleGraphic;//the turtle graphic NOT the collider!
	public GameObject ActualTurtle;//the turtle collider
	private Rigidbody2D TurtleRigidBody;
	public float AngleOfTurtle;//The angle the turtle graphic is in world space
	private TurtleMovementScript TurtleMoveScr;
	public float velocityOfTurtle;//the velocity of the turtle
	public float MaxSpeedForRotation = 0;//the maximum velocity the turlte can go for the turtle to rotate with the script
	public float angleSpeed = 50;//how many degrees the angle decreases per second
	private float AngleSpeedConst;//this is the same as anglespeed but isnt affected by acceleration, is used when you want to set anglespeed back to its original value
	public float angleAcceleration = 10;//how quickly the turtle angle speed acelerates 
	public Vector3 GlobalRotation = new Vector3 (0, 0, 0);//This is used as you cannot direcctly change turtleGraphic.transform.eulerAngles
	public float WhichWayToRotate = 1;// used to show which way the turle must rotate when it stops. 
	public float MaxAngleToStopRotation = 1;
	// Use this for initialization
	void Start ()
	{
		TurtleRigidBody = ActualTurtle.GetComponent<Rigidbody2D> ();
		TurtleMoveScr = ActualTurtle.GetComponent<TurtleMovementScript> ();

		AngleSpeedConst = angleSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		RotateTurtle ();
	}

	void RotateTurtle ()//Rotates the turtle back to 0 degrees
	{

		velocityOfTurtle = Mathf.Abs (TurtleRigidBody.velocity.x); //gets the velocity of the turtle
		if (velocityOfTurtle <= MaxSpeedForRotation) {

			AngleOfTurtle = TurtleGraphic.transform.eulerAngles.z;//gets the angle of the turtle graphic

			if (AngleOfTurtle < MaxAngleToStopRotation || AngleOfTurtle >360 - MaxAngleToStopRotation) {
				AngleOfTurtle=0;
			}
			else
			{

				AngleOfTurtle -= 180;//This is so the angles are either positive or negative i.e 120-180 = negative and 350-180= positive
				//float PrevWhichWayToRotate= WhichWayToRotate;
				if (AngleOfTurtle < 0) {
					WhichWayToRotate = -1;
				} else if (AngleOfTurtle > 0) {
					WhichWayToRotate = 1;
				}
				
				AngleOfTurtle += angleSpeed * Time.deltaTime * WhichWayToRotate;//adds angleSpeed per second but in the direction it needs to rotate

					AngleOfTurtle += 180;
				
				angleSpeed += angleAcceleration * Time.deltaTime;
			}

			GlobalRotation.z = AngleOfTurtle;//used as you cannot directly change  turtlegraphic.transform.eulerangles.Z
			TurtleGraphic.transform.eulerAngles = GlobalRotation;
		} else {
			angleSpeed = AngleSpeedConst;
		}

	}
}








