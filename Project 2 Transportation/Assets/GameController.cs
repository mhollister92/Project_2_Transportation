using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cubePrefab;
	int xNumber = 16;
	int yNumber = 9;
	private GameObject [,] allCubes;	//array to keep track of cubes
	Airplane myAirplane;
	Train myTrain;
	Boat myBoat;

	float turn = 1.5f;
    int score = 0;
	float timeToAct;

	int xLocation = 0;
	int yLocation = 8;

	float timer;
	float minutes;
	float seconds;
	float hours;
	string minutesString;
	string secondsString;
	string hoursString;

	//Function to change color of clicked cube
	public void ProcessClickedCube (GameObject clickedCube, int x, int y)
	{
		//make airplane active and change color to yellow
		if (x == myAirplane.x && y == myAirplane.y && myAirplane.active == false) {
			myAirplane.active = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
			//stops the cube from continuing movement once reactivated
			xLocation = x;
			yLocation = y;
			//deactivates boat or train
			myBoat.active = false;
			allCubes [myBoat.x, myBoat.y].GetComponent<Renderer> ().material.color = Color.blue;
			myTrain.active = false;
			allCubes [myTrain.x, myTrain.y].GetComponent<Renderer> ().material.color = Color.green;
		}

		//make boat active and change color
		else if (x == myBoat.x && y == myBoat.y && myBoat.active == false) {
			myBoat.active = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
			//stops the cube from continuing movement once reactivated
			xLocation = x;
			yLocation = y;
			//deactivates boat or train
			myAirplane.active = false;
			allCubes [myAirplane.x, myAirplane.y].GetComponent<Renderer> ().material.color = Color.red;
			myTrain.active = false;
			allCubes [myTrain.x, myTrain.y].GetComponent<Renderer> ().material.color = Color.green;
		}
		//make train active and change color
		else if (x == myTrain.x && y == myTrain.y && myTrain.active == false) {
			myTrain.active = true;
			clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
			//stops the cube from continuing movement once reactivated
			xLocation = x;
			yLocation = y;
			//deactivates boat or train
			myAirplane.active = false;
			allCubes [myAirplane.x, myAirplane.y].GetComponent<Renderer> ().material.color = Color.red;
			myBoat.active = false;
			allCubes [myBoat.x, myBoat.y].GetComponent<Renderer> ().material.color = Color.blue;
		} 

		//make airplane inactive and change color to red
		else if (x == myAirplane.x && y == myAirplane.y && myAirplane.active) {
			myAirplane.active = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		} 
		//make boat inactive
		else if (x == myBoat.x && y == myBoat.y && myBoat.active) {
			myBoat.active = false;
			clickedCube.GetComponent<Renderer> ().material.color = Color.blue;
		} 
		//make train inactive
		else if (x == myTrain.x && y == myTrain.y && myTrain.active) {
			myTrain.active = false;
			clickedCube.GetComponent<Renderer>().material.color = Color.green;
		}

		else if (((x != myAirplane.x || y != myAirplane.y) ||
		         (x != myBoat.x || y != myBoat.y) ||
		         (x != myTrain.x || y != myTrain.y)) && 
		         (myAirplane.active || myBoat.active || myTrain.active))
		{
			xLocation = x;
			yLocation = y;
		}
	}

	// Use this for initialization
	void Start () {
		myAirplane = new Airplane ();
		myBoat = new Boat ();
		myTrain = new Train ();

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
		myAirplane.active = false;

		//set start location of train
		myTrain.x = 0;
		myTrain.y = 0;
		allCubes [0, 0].GetComponent<Renderer> ().material.color = Color.green;
		myTrain.active = false;

		//set start location of boat
		myBoat.x = 15;
		myBoat.y = 8;
		allCubes [15, 8].GetComponent<Renderer> ().material.color = Color.blue;
		myBoat.active = false;

		//make bottom corner depot and turn black (Need to keep it from turning white after airplane is there)
		allCubes [15, 0].GetComponent<Renderer> ().material.color = Color.black;

		timeToAct = turn;
	}

	void OnGUI()
	{
		//score and cargo
		GUI.Label (new Rect (5, 1, 100, 20), "Score: " + score);
		if (myAirplane.active) {
			GUI.Label (new Rect (150, 1, 100, 20), "Cargo: " + myAirplane.cargo);
		} else if (myTrain.active) {
			GUI.Label (new Rect (150, 1, 100, 20), "Cargo: " + myTrain.cargo);
		} else if (myBoat.active) {
			GUI.Label (new Rect (150, 1, 100, 20), "Cargo: " + myBoat.cargo);
		}
		//timer
		timer = Time.time;
		hours = timer / 3600;
		hours = (int)hours;
		minutes = timer / 60;
		minutes = (int)minutes;
		seconds = timer % 60;
		seconds = (int)seconds;
		if (minutes < 10) 
		{
			minutesString = "0" + minutes.ToString ();
		} 
		else 
		{
			minutesString = minutes.ToString ();
		}
		if (seconds < 10) 
		{
			secondsString = "0" + seconds.ToString ();
		} 
		else 
		{
			secondsString = seconds.ToString ();
		}
		if (hours < 10) {
			hoursString = "0" + hours.ToString ();
		} 
		else 
		{
			hoursString = hours.ToString ();
		}
		GUI.Label (new Rect (300, 1, 100, 20),hoursString + ":" + minutesString + ":" + secondsString);
	}

	// Update is called once per frame
	void Update () {
		//things to do every turn
		if (Time.time >= timeToAct && myAirplane.active) {
			//increase cargo
			if(myAirplane.x == 0 && myAirplane.y == 8 && myAirplane.active)
			{
				myAirplane.AddCargo ();
			}
			//if cube is on depot, empty cargo
			else if(myAirplane.x == 15 && myAirplane.y == 0 && myAirplane.active)
			{
				score += (myAirplane.cargo/10);
				myAirplane.cargo = 0;
			}
			//turn old airplane spot into sky
			allCubes[myAirplane.x, myAirplane.y].GetComponent<Renderer>().material.color = Color.white;
			//move airplane
			myAirplane.MoveAirplane(xLocation, yLocation);
			//turn new airplane cube yellow
			allCubes[myAirplane.x, myAirplane.y].GetComponent<Renderer>().material.color = Color.yellow;
			timeToAct += turn;
		}

		else if (Time.time >= timeToAct && myTrain.active) {
			//if cube is on start spot, increase cargo
			if(myTrain.x == 0 && myTrain.y == 0 && myTrain.active)
			{
				myTrain.AddCargo();
			}
			else if(myTrain.x == 15 && myTrain.y == 0 && myTrain.active)
			{
				score += (myTrain.cargo/10);
				myTrain.cargo = 0;
			}
			//turn old train spot into sky
			allCubes[myTrain.x, myTrain.y].GetComponent<Renderer>().material.color = Color.white;
			//move train
			myTrain.moveTrain(xLocation, yLocation);
			//turn new train cube yellow
			allCubes[myTrain.x, myTrain.y].GetComponent<Renderer>().material.color = Color.yellow;
			timeToAct += 2*turn;
		}

		else if (Time.time >= timeToAct && myBoat.active) {
			if(myBoat.x == 15 && myBoat.y == 8 && myBoat.active)
			{
				myBoat.AddCargo ();
			}
			else if(myBoat.x == 15 && myBoat.y == 0 && myBoat.active)
			{
				score += (myBoat.cargo/10);
				myBoat.cargo = 0;
			}
			//turn old boat spot into sky
			allCubes[myBoat.x, myBoat.y].GetComponent<Renderer>().material.color = Color.white;
			//move boat
			myBoat.moveBoat(xLocation, yLocation);
			//turn new boat cube yellow
			allCubes[myBoat.x, myBoat.y].GetComponent<Renderer>().material.color = Color.yellow;

			timeToAct += 3*turn;
		}
		//keeps depot black
		if ((myAirplane.x != 15 || myAirplane.y != 0) && (myTrain.x != 15 || myTrain.y != 0) &&
		    (myBoat.x != 15 || myBoat.y != 0)) {
			allCubes [15, 0].GetComponent<Renderer> ().material.color = Color.black;
		}
		//keeps cubes same color if they overlap
		if ((myAirplane.x != myBoat.x || myAirplane.y != myBoat.y) && 
		    (myTrain.x != myBoat.x || myTrain.y != myBoat.y) && 
		    (myAirplane.x != myTrain.x || myAirplane.y != myTrain.y))
		{
			if(myBoat.active == false)
			{
				allCubes[myBoat.x, myBoat.y].GetComponent<Renderer>().material.color = Color.blue;
			}
			if(myTrain.active == false)
			{
				allCubes[myTrain.x, myTrain.y].GetComponent<Renderer>().material.color = Color.green;
			}
			if(myAirplane.active == false)
			{
				allCubes[myAirplane.x, myAirplane.y].GetComponent<Renderer>().material.color = Color.red;
			}
		}
}
}
