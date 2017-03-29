using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public float speed = 30f;  // ?how can i set this value on the Inspector?
	//public float OriRoSpeed;

//this rotating speed is the first energy of this world
	public float Speed
	{
		get{ return speed; }
		set { speed = value;}
	} 

    public float timeHere;

	public float radius_currentWheel;

	public GameObject go_collide_w1;

	GameObject lGameManager;

	void Start () 
	{

		//Speed = OriRoSpeed;
	}

	void Update () 
	{
		radius_currentWheel = transform.localScale.x;

		transform.Rotate (0,0, Time.deltaTime * Speed);

////create a time of this wheel
		timeHere = timeHere + Time.deltaTime * Speed;
		//Debug.Log ("TimeHere w1: " + timeHere);


		//Debug.Log (GameManager.gear);

		lGameManager = GameObject.Find ("GameManager");
	}
		

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "wheel") 
		{
			go_collide_w1 = other.gameObject;

			//go_collides_w1.Add (go_collide);

			if (GameManager.gear_collides.Contains (go_collide_w1)) 
			{
			} 
			else 
			{
				GameManager.gear_collides.Add (go_collide_w1);
			}

			//Debug.Log ("collide");
			lGameManager.SendMessage ("whenListChange");

		}

	}
}
