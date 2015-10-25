using UnityEngine;
using UnityEditor;
using System.Collections;

public class ContactScript : MonoBehaviour {


	int currentLevel;
	int LevelNum=1;
	Object prefab;
	GameObject map;

	// Use this for initialization
	void Start () {

		prefab = Resources.Load ("Level"+LevelNum);
		map = Instantiate (prefab, new Vector2 (0, 0),Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		LevelNum++;

		prefab = Resources.Load ("Level"+LevelNum);
		map = Instantiate(prefab, new Vector2 (20,0), Quaternion.identity) as GameObject;
	}

	void OnCollisionExit2D(Collision2D collision) 
	{

	}


}
