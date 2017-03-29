using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_rotate : MonoBehaviour {

	//public GameObject ooo;
	rotate lrotate; 

	public float timeHere;

	//GameObject[] allWheels;
	List<GameObject> allWheels;
	public float aspeed;
	public float  stable_aspeed; 

	follow_rotate lfollow_rotate; 

	GameObject lw1;

	public bool attachToW1;

	float multiplescale_w_nearest;

	GameObject lw2;

	public Vector3 v3_currentNearestWheel;
	public float radius_currentWheel;

	public GameObject closestObject;

	public GameObject attachGameObject_1;
	public GameObject attachGameObject_2;
	public GameObject attachGameObject_3;

	public GameObject go_collide;
	public List<GameObject> go_collides;

	public GameObject public_collision;

	GameObject lGameManager;


	void Start () 
	{
		lrotate = new rotate ();
	
		timeHere = 0;

		lw1 = GameObject.Find ("w1");

		attachToW1 = false;

		lw2 = GameObject.Find ("w2");

////find te nearest object from this wheel
		allWheels = new List<GameObject>();
		allWheels.AddRange(GameObject.FindGameObjectsWithTag("wheel"));
		allWheels.Remove (gameObject); //exclude this gameobject from the list.
		//Debug.Log ("amounts of the Wheels: " + allWheels.Count);

		lGameManager = GameObject.Find ("GameManager");

	}
		

	void Update () 
	{

			
////find te nearest object from this wheel
		float closest = 1000;
	    closestObject= null;
		for(int i=0; i < allWheels.Count; i++)
		{
			float dist = Vector3.Distance (allWheels [i].transform.position , transform.position) 
				- allWheels [i].transform.localScale.x/2 - transform.localScale.x/2;
			if (dist < closest) 
			{
				closest = dist;
				closestObject = allWheels[i];

				lfollow_rotate = closestObject.GetComponent<follow_rotate>();
			}
		}
		//Debug.Log (gameObject + "'s the nearest: " + closestObject);


//// get the multiple of the sclae between this object and the nearest object
		multiplescale_w_nearest =  transform.localScale.x / closestObject.transform.localScale.x; 
		//Debug.Log (gameObject +": " + multiplescale_w1);


////get the position of the nerest wheel here and tell the npc2.cs, and the radius
		v3_currentNearestWheel = closestObject.transform.position;
		radius_currentWheel = transform.localScale.x;

////claim this wheel's speed

////roate with normal wheels
		if (closest != null) 
		{
////roate with the orignal wheel.

			//float nearest_multiplescale = 

			if (closestObject == lw1)
			{			
				
				aspeed = Time.deltaTime * (-lrotate.Speed )/transform.localScale.x /*multiplescale_w_nearest*/;

				attachToW1 = true; //is this value the only one value attatched to the gameobject?
				//Debug.Log (gameObject + "roate following w1!!!!");
				//chooseAttachGameObject ();
			}
////rotate wit the normal wheels
			if (closestObject != lw1) {

				bool nearest_attachToW1 = closestObject.GetComponent<follow_rotate> ().attachToW1;

				float nearest_aspeed = closestObject.GetComponent<follow_rotate> ().aspeed;
				//float nearest_stable_aspeed = closestObject.GetComponent<follow_rotate> ().stable_aspeed;

				//Debug.Log ("nearest_aspeed: " + nearest_aspeed);

				if (nearest_attachToW1) //!!!should the object's attachToW1,not this object's attachToW1!
				{

					////这个轮子的速度 = 上一个轮子的速度 * 半径大小的变化
					aspeed = - nearest_aspeed / multiplescale_w_nearest;

					attachToW1 = true; 
					//attachToW1 = true;

					//chooseAttachGameObject ();
				}
				
			}
				
		}
		float d = Vector2.Distance(transform.position, closestObject.transform.position);
		//print (d);
//		print (transform.localScale.x);
//		print (Mathf.Abs(-10f));
//		print (transform.localScale.x/2 + ooo.transform.localScale.x/2 - d);


////judge when to start roating
////judge if two ajacent wheels can collide,
////if so, rotate following the speed of wheel
		if (Mathf.Abs (transform.localScale.x/2 + closestObject.transform.localScale.x/2 - d) < 0.2f) 
		{
			//print ("two wheels can collide.");
			transform.Rotate (0,0, aspeed);

////create a time of this Wheel
////and make this time update following the state of the wheel 
			timeHere = timeHere + Time.deltaTime * lrotate.Speed/multiplescale_w_nearest;
			//Debug.Log ("timeHere w2: "  + timeHere );
		}
			
		Debug.DrawLine (transform.position,  go_collide.transform.position, Color.yellow);


	}

	/// / when there is a nearest gameobeject, mark it as "attachGameObject_1","attachGameObject_2""attachGameObject_3"

	void OnTriggerEnter2D(Collider2D other)
	{

		//go_collide = other.gameObject;

		//go_collides.Add (go_collide);

		if (other.tag == "wheel") 
		{
			go_collide = other.gameObject;

			//go_collides_w1.Add (go_collide);

			if (GameManager.gear_collides.Contains (go_collide)) 
			{
			} 
			else 
			{
				GameManager.gear_collides.Add (go_collide);
			}

			//Debug.Log ("collide");

			lGameManager.SendMessage ("whenListChange");
		}
	}


}
