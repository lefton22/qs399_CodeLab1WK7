using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class saveload : MonoBehaviour {

	string saveFileName;
	string saveFilePath;

	List<GameObject> allWheels;

	const char DELIMITER = '|';

	void Start () 
	{
		saveFileName = "save1.txt";
		saveFilePath = Application.dataPath + "/" + saveFileName;

		allWheels = new List<GameObject>();
		allWheels.AddRange(GameObject.FindGameObjectsWithTag("wheel"));
		Debug.Log ("allWheels: " + allWheels.Count);

		if (File.Exists (saveFilePath)) 
		{
			Debug.Log ("txt exist");

			//StreamReader sr = new StreamReader (fil);
		}
	}
	

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Debug.Log ("save!");

			save ();
		}

		if (Input.GetKeyDown (KeyCode.J)) 
		{
			Debug.Log ("load!");

			load ();
		}
	}

	void save()
	{
		StreamWriter sw = new StreamWriter (saveFilePath, false);

		foreach(GameObject obj in allWheels)
		{
			Debug.Log ("allWheels' Pos: "+obj.transform.position);

			sw.WriteLine ("" +
				obj.transform.position + DELIMITER,
				saveFileName);
			
		}
		sw.Close ();
	}

	void load()
	{
		StreamReader sr = new StreamReader(saveFilePath);
//		string line = sr.ReadLine();
//		sr.Close();
//
//		//Debug.Log ("line: " + line);
//
//		string[] splitLine = line.Split (DELIMITER);
//		Debug.Log ("line: " + splitLine);

		while (!sr.EndOfStream) 
		{
//			string line = sr.ReadLine;
//			string[] splitLine = line.Split (DELIMITER);
//			string pos = splitLine [0];

//			Debug.Log ("WheelsPos: " + pos);
		}
		sr.Close ();
	}

}
