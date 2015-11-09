using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
	GameController aGameController;
	public int x;
	public int y;

	bool isEnlarged = false;

	// Use this for initialization
	void Start () {
		aGameController = GameObject.Find ("GameControllerObject").GetComponent<GameController> ();
	
	}

	void OnMouseDown ()
	{
		aGameController.ProcessClickedCube (this.gameObject, x, y);
	}

	void OnMouseEnter()
	{
		isEnlarged = true;
	}
	void OnMouseExit()
	{
		isEnlarged = false;
	}
	// Update is called once per frame
	void Update () {
		if (isEnlarged) {
			gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
		}
		if (isEnlarged == false) {
			gameObject.transform.localScale = new Vector3(1, 1, 1);
		}
	
	}
}
