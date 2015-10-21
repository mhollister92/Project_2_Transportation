using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cubePrefab;
	int xNumber = 16;
	int yNumber = 9;
	private GameObject [,] allCubes;	//array to keep track of cubes
	Airplane myAirplane;

	//Function to change color of clicked cube
	public void ProcessClickedCube (GameObject clickedCube, int x, int y)
	{
		//make airplane active and change color to yellow
		if (x == myAirplane.x && y == myAirplane.y && myAirplane.active == false) {
			myAirplane.active = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
		} 
		//make airplane inactive and change color to red
		else if (x == myAirplane.x && y == myAirplane.y && myAirplane.active) {
			myAirplane.active = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		} 
		//move airplane location and turn old airplane white
		else if ((x != myAirplane.x || y != myAirplane.y) && myAirplane.active) {
			allCubes[myAirplane.x, myAirplane.y].GetComponent<Renderer>().material.color = Color.white;
			allCubes[x,y].GetComponent<Renderer>().material.color = Color.yellow;
			myAirplane.x = x;
			myAirplane.y = y;
		}
	}

	// Use this for initialization
	void Start () {
		myAirplane = new Airplane ();
		allCubes = new GameObject[xNumber,yNumber];
		// creates 16 cubes
		for (int xcount = 0; xcount < xNumber; xcount++) 
		{
			for (int ycount = 0; ycount < yNumber; ycount++)
			{
				allCubes[xcount,ycount] = (GameObject)
					Instantiate(cubePrefab, new Vector3((xcount*2) - 16,(ycount*2) - 10, 0), 
				            Quaternion.identity);
				allCubes[xcount,ycount].GetComponent<CubeBehavior>().x = xcount;
				allCubes[xcount,ycount].GetComponent<CubeBehavior>().y = ycount;
			}
		}
		// set start location of airplane
		myAirplane.x = 0;
		myAirplane.y = 8;
		allCubes [0, 8].GetComponent<Renderer> ().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
