using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placewheels : MonoBehaviour {

	int whichWHeel;
	bool isClick;
	bool isClick2;
	bool isFollowCilck;
	GameObject lline_w2;
	GameObject lline_w3;

	void Start () 
	{
		whichWHeel = 0;
		isClick = true;
		isFollowCilck = false;

		lline_w2 = GameObject.Find ("line_w2");
		lline_w3 = GameObject.Find ("line_w3");

	}
	

	void Update () 
	{

		//Debug.Log ("isClick: "+ isClick);

////if click the button1, w2 will follow the mouse until click agian and place w2 to a new place.
		if (whichWHeel == 1)
		{
			isClick = false;

////w2 follow my mouse!
		
//			if (!isFollowCilck)
//			{
//			//Vector3 mouseV3_2 = Input.mousePosition;
//			
//			Vector3 mouseV3_2 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			mouseV3_2.z = 0f;
//
//			GameObject wheel_l = Instantiate(Resources.Load("line_w2"), mouseV3_2, Quaternion.identity) as GameObject;
//
//			isFollowCilck = true; 
//			}
//			//lline_w2.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);


////and then click to place the wheel
			if (Input.GetMouseButtonDown (0)  && !isClick) 
			{
				//Vector3 mouseV3 = Camera.main.ScreenToViewportPoint (Input.mousePosition);
				Vector3 mouseV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mouseV3.z = 0;
				//Debug.Log ("mouse position: " + mouseV3 /*+"  2position: " + Input.mousePosition*/);

////initiate a wheel from refab

				GameObject wheel_n = Instantiate(Resources.Load("w2"), mouseV3, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
				                                                                                                    //mouseV3 is the place which it will be born. 

				isClick = true;
				whichWHeel = 0;
				lline_w2.SendMessage ("hide");
			}


		}

		if (whichWHeel == 2)
		{
			isClick2 = false;


			if (Input.GetMouseButtonDown (0)  && !isClick2) 
			{
				//Vector3 mouseV3 = Camera.main.ScreenToViewportPoint (Input.mousePosition);
				Vector3 mouseV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mouseV3.z = 0;
				//Debug.Log ("mouse position: " + mouseV3 /*+"  2position: " + Input.mousePosition*/);

				////initiate a wheel from refab

				GameObject wheel_n2 = Instantiate(Resources.Load("w3"), mouseV3, Quaternion.identity) as GameObject; // "w2"is the name in the Resources file,
				//mouseV3 is the place which it will be born. 

				isClick2 = true;
				whichWHeel = 0;
				lline_w3.SendMessage ("hide");
			}


		}


	}

	public void pickupW2()
	{
		whichWHeel = 1;
		print ("run pickupW2();" +"whichWHeel: " + whichWHeel);

		lline_w2.SendMessage ("appear");
	}

	public void pickupW3()
	{
		whichWHeel = 2;
		print ("run pickupW3();" +"whichWHeel: " + whichWHeel);

		lline_w3.SendMessage ("appear");
	}
}
