using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class readJSON : MonoBehaviour {

	string path;
	public string jsonString;

	void Start () 
	{
		path = Application.streamingAssetsPath + "/ju.json";
//		jsonString = File.ReadAllText (path);
	}
	
	// Update is called once per frame
	void Update () 
	{
		jsonString = File.ReadAllText (path);
		//Debug.Log ("ju:  " + jsonString);
	}
}
