using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_w3 : MonoBehaviour {

	SpriteRenderer sp_line_w3;

	void Start () 
	{
		sp_line_w3 = this.gameObject.GetComponent<SpriteRenderer> ();	
	}


	void Update () 
	{
		Vector3 mouseV3_2 = Input.mousePosition;

		mouseV3_2 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouseV3_2.z = 0f;
		transform.position =  mouseV3_2;

	}

	void appear()
	{
		Debug.Log ("hide!");
		sp_line_w3.enabled = true;
	}

	void hide()
	{
		//Debug.Log ("hide!");
		sp_line_w3.enabled = false;
	}
}
