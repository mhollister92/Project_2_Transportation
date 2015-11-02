using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cubePrefab;
	int xNumber = 16;
	int yNumber = 9;
	private GameObject [,] allCubes;	//array to keep track of cubes
	Airplane myAirplane;

	float turn = 1.5f;
	int score = 0;
	float timeToAct;

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
		/*move airplane location and turn old airplane white
		else if ((x != myAirplane.x || y != myAirplane.y) && myAirplane.active) {
			allCubes[myAirplane.x, myAirplane.y].GetComponent<Renderer>().material.color = Color.white;
			allCubes[x,y].GetComponent<Renderer>().material.color = Color.yellow;
			myAirplane.x = x;
			myAirplane.y = y;
		}
		*/
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

		//make bottom corner depot and turn black (Need to keep it from turning white after airplane is there)
		allCubes [15, 0].GetComponent<Renderer> ().material.color = Color.black;

		timeToAct = turn;
	}

	void OnGUI()
	{
		GUI.Label (new Rect (5, 1, 100, 20), "Score: " + score);
		GUI.Label (new Rect (150, 1, 100, 20), "Cargo: " + myAirplane.cargo);
	}

	// Update is called once per frame
	void Update () {

		//record the move direction of the airplane and make sure it is on the grid
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (myAirplane.y < 8)
			{
				myAirplane.SetMoveDirection (0, 1);
			}
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (myAirplane.y > 0)
			{
				myAirplane.SetMoveDirection(0, -1);
			}
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if(myAirplane.x > 0)
			{
				myAirplane.SetMoveDirection(-1, 0);
			}
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (myAirplane.x < 15)
			{
				myAirplane.SetMoveDirection(1, 0);
			}
		}
		//keeps depot black
		if (myAirplane.x != 15 || myAirplane.y != 0) {
			allCubes [15, 0].GetComponent<Renderer> ().material.color = Color.black;
		}
		//things to do every turn
		if (Time.time >= timeToAct && myAirplane.active) {
			//turn old airplane spot into sky
			allCubes[myAirplane.x, myAirplane.y].GetComponent<Renderer>().material.color = Color.white;
			//move airplane
			myAirplane.MoveAirplane();
			//turn new airplane cube yellow
			allCubes[myAirplane.x, myAirplane.y].GetComponent<Renderer>().material.color = Color.yellow;
			//if cube is on start spot, increase cargo
			if((myAirplane.x == 0 && myAirplane.y == 8) && myAirplane.active)
			{
				if(myAirplane.cargo < myAirplane.cargoCapacity)
				{
					myAirplane.cargo += 10;
				}
			}
			//if cube is on depot, empty cargo
			else if((myAirplane.x == 15 && myAirplane.y == 0) && myAirplane.active)
			{
				score += (myAirplane.cargo / 10);
				myAirplane.cargo = 0;
			}

			timeToAct += turn;
		}
}
}
