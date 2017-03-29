using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phy_rotate : MonoBehaviour {
	
	public float thrust;
	public Rigidbody2D rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.Rotate (0,0,Time.deltaTime * 20f);
		rb.AddForce(transform.up * thrust);
	}
}
