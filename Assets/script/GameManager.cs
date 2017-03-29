using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static List <GameObject> gear_collides;

	GameObject lw2;

	public static int gear;




	void Start () 
	{

		gear_collides = new List<GameObject>();

//		lw2 = GameObject.Find ("w2");
//		gear_collides.Clear (); 

		//Debug.Log (lw2);

//        gear_collides.Add (lw2);
//
//		gear_collides.Clear (); 

//		gear =1;

//		Debug.Log ("beginning what's in gear_collides: " + gear_collides[0]);
		//Debug.Log (gear);


	}
	

	void Update () 
	{
//		gear++;

	}

	void whenListChange()
	{
		for (int i = 0; i < GameManager.gear_collides.Count; i++) 
		{
			Debug.Log ("colliding what's in gear_collides: " + i +": "+ GameManager.gear_collides [i]);
		}
	}
}
