using UnityEngine;
using System.Collections;

public class setSortingLayer : MonoBehaviour {
	private Renderer render;//renderer
	public int sortingLayer=-100;//layer that the object renders, i.e at the front or at the back
	public KeyCode GravityButton;
	
	// Use this for initialization
	void Start () {
		render= GetComponent<Renderer> ();//set the renderer

	}
	
	// Update is called once per frame
	void Update () {
		SetLayer ();//calls the setLayer function
	}
	void SetLayer()
	{

		if (Input.GetKeyDown (GravityButton)) {//if gravity is flipped
			sortingLayer*=-1;//move layer from back to front or visa versa


		}
		render.sortingOrder= sortingLayer;//set the layer
	}
}
