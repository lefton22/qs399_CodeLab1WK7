using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meetwho : MonoBehaviour {

	public SpriteRenderer renderer;

	int layer; // this npc's level

	void Start () 
	{
		renderer = this.GetComponent<SpriteRenderer>();

		layer = 1;
			
	}
	

	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D meeter)
	{
		
////first layer of mutation
		//gain the meeter's spriteRenderer
		SpriteRenderer rr = meeter.GetComponent<meetwho> ().renderer; 

		if (/* meeter.gameObject.name == "npc1" */ layer == 1 && meeter.tag == "npc") 
		{
			Debug.Log ("meet in l1");
			if (gameObject.tag == "npc") 
			{
//			GameObject g1 = gameObject;
//			GameObject g2 = meeter.gameObject;

				//give a tag to differentiate the "meeter" and the "meet", depends on the order of reading the script
				gameObject.tag = "test";

				//destroy one object has the tag above
				GameObject g1 = GameObject.FindWithTag ("test");
				Destroy (g1);

				//change the meeter's color
				rr.color = Color.red;
				Debug.Log ("they meet in level1!!");

				// open the condition of the next level and give the rest npc a new tag
				//gameObject.tag ="npc2";
				layer = 2;
				meeter.tag = "npc2";

				Debug.Log ("layer: " + layer);
			}
		
		}

//		 else if ( layer == 2 && meeter.tag == "npc2") 
//		{
//			if (gameObject.tag == "npc") 
//			{
//				gameObject.tag = "test2";
//
//				GameObject g1 = GameObject.FindWithTag ("test2");
//				Destroy (g1);
//
//				rr.color = Color.blue;
//
//				Debug.Log ("meet in level 2-1");
//
//				layer = 3;
//				meeter.tag = "npc2";
//
//				Debug.Log ("layer: " + layer);
//			}
//
//			if (gameObject.tag == "npc2") 
//			{
//				gameObject.tag = "test3";
//
//				GameObject g1 = GameObject.FindWithTag ("test3");
//				Destroy (g1);
//
//				rr.color = Color.blue;
//
//				Debug.Log ("meet in level 2-2");
//
//				layer = 3;
//				meeter.tag = "npc2";
//
//				Debug.Log ("layer: " + layer);
//
//			}
//		}

	}
}
