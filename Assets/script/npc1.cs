using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc1 : MonoBehaviour {
	
	GameObject myParent;
	Vector3 v3_parent;
	Vector3 v3_intersectPoint;

	Vector3 v3_worldPos;
	GameObject nearestWheel;

	GameObject lw1;
	GameObject lgo_collide;
	List<GameObject> lgo_collides;

	float radius_collided;

	bool isChangeTrail;

	float meetTime;



	void Start () 
	{
////find the parent and get the parent's axis
		myParent =  transform.parent.gameObject;

		lw1 = GameObject.Find ("w1");

		//Debug.Log (" npc1's parent: " + transform.parent.gameObject);
		isChangeTrail = true;

	}
	

	void Update ()
	{
		float radius = myParent.transform.localScale.x;

		v3_parent = myParent.transform.position;

	
		//transform.localPosition = new Vector3 (/*parent.transform.localScale.x/4f*/0.5f,0,0);

		////get all the gameobjects collided with this npc's parent?

		if (myParent != lw1)
		{
		lgo_collides = myParent.GetComponent<follow_rotate> ().go_collides; 
		//Debug.Log ("go_cillides: " + lgo_collides[0] + " " + lgo_collides[1] + " " + lgo_collides[2] );
			//Debug.Log(gameObject + " not w1...");
		}

//		if (myParent == lw1) 
//		{
//		lgo_collides = myParent.GetComponent<follow_rotate> ().go_collides; 
//		}


		for (int i = 0; i < lgo_collides.Count; i++) 

		{ 

////find the collided wheel from the parent wheel, and get the position

			Vector3 v3_lgo_collides = lgo_collides[i].transform.position;

			if (lgo_collides[i] == lw1)
			{
				 radius_collided = lgo_collides[i].GetComponent<rotate> ().radius_currentWheel; 
			}

			if (lgo_collides [i] != lw1) 
			{
				 radius_collided = lgo_collides [i].GetComponent<follow_rotate> ().radius_currentWheel; 
			}
			//Debug.Log ("v3_parentsNearest: " +v3_parentsNearest + "this parent: " + v3_parent);

////calculate the cross point of two wheels

			Vector3 dist_two =   v3_lgo_collides - v3_parent;

			v3_intersectPoint = v3_parent + dist_two.normalized * /*radius_collided / 2f*/ radius/2f;

//// create a collider at the position of cross point, and if any npc collide with this collider, change tha parent
			v3_worldPos = transform.TransformPoint (transform.position);
			//Debug.Log ("v3_worldPos: " + v3_worldPos);

////ctreat only one cross point for every tw crossing wheels
			/// if the cross point is near the npc,cross

			if (Mathf.Abs (v3_intersectPoint.x - transform.position.x) < 0.2f &&
				Mathf.Abs (v3_intersectPoint.y - transform.position.y) < 0.2f && isChangeTrail ) 
			{
				Transform currentWorldPos = transform;

				transform.SetParent (lgo_collides[i].transform); 
				myParent = lgo_collides [i];

				transform.position = v3_intersectPoint;
		
				isChangeTrail = false;

				meetTime = Time.time;

			}

			if(	Time.time - meetTime > 1.5f) 
			{
				isChangeTrail = true;
			}

			//Debug.Log("isChangeTrial: " +isChangeTrail);

		}

		//Debug.Log ("npc's nearest gameobject is: " + nearestWheel);

//		//if there is no same collision here
//		//if there is no collider there, then create the collider:
//		//once: 
//		GameObject wheel_n = Instantiate(Resources.Load("crosspoint"), v3_intersectPoint, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
//		                                                                                             //mouseV3 is the place which it will be born. 	

	}


	///  and if any npc collide with this collider, change tha parent

}
