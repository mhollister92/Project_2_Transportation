using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	GameController aGameController;

	// Use this for initialization
	void Start () {
		aGameController = GameObject.Find ("GameControllerObject").GetComponent<GameController> ();
	
	}

	void OnMouseDown ()
	{
		aGameController.ProcessClickedCube (this.gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
