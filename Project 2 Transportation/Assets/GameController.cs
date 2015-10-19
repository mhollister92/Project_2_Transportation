using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cubePrefab;
	int xNumber = 16;
	int yNumber = 9;
	private GameObject [] allCubes;	//array to keep track of cubes
	Airplane myAirplane;

	//Function to change color of clicked cube
	public void ProcessClickedCube (GameObject clickedCube)
	{
		foreach (GameObject oneCube in allCubes) 
		{
			oneCube.GetComponent<Renderer>().material.color = Color.white;
		}
		clickedCube.GetComponent<Renderer> ().material.color = Color.red;
	}

	// Use this for initialization
	void Start () {
		allCubes = new GameObject[xNumber];
		// creates 16 cubes
		for (int xcount = 0; xcount < xNumber; xcount++) 
		{
				allCubes[xcount] = (GameObject)
					Instantiate(cubePrefab, new Vector3((xcount*2) - 16, 0, 0), 
				            Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
