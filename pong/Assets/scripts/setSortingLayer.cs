using UnityEngine;
using System.Collections;

public class setSortingLayer : MonoBehaviour {
	private Renderer render;
	public int sortingLayer=-2;
	
	// Use this for initialization
	void Start () {
		render= GetComponent<Renderer> ();
		if (render) {
			render.sortingOrder= sortingLayer;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
