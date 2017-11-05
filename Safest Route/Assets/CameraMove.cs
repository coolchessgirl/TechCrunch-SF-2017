using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour {

	public Toggle birdsEye;
	public GameObject camera1;
	public GameObject camera2;
	public Camera c1;
	public Camera c2;

	//public GameObject camera1parent;
	// Use this for initialization
	void Start () {
		//birdsEye.enabled = false;
		c1.enabled = true;
		c2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (birdsEye.isOn) {
			c1.enabled = true;
			c2.enabled = false;
			if (Input.GetKey ("up"))
				camera1.transform.Translate (Vector3.forward * Time.deltaTime * 100);
			if (Input.GetKey ("down"))
				camera1.transform.Translate (Vector3.back * Time.deltaTime * 100);
			if (Input.GetKey ("left"))
				camera1.transform.Translate (Vector3.left * Time.deltaTime * 100);
			if (Input.GetKey ("right"))
				camera1.transform.Translate (Vector3.right * Time.deltaTime * 100);
		} 
		else {
			c1.enabled = false;
			c2.enabled = true;
			if (Input.GetKey ("up"))
				c2.transform.Translate (Vector3.forward * Time.deltaTime * 100);
			if (Input.GetKey ("down"))
				c2.transform.Translate (Vector3.back * Time.deltaTime * 100);
			if (Input.GetKey ("left"))
				c2.transform.Rotate (Vector3.down * Time.deltaTime * 100);
			if (Input.GetKey ("right"))
				c2.transform.Rotate (Vector3.up * Time.deltaTime * 100);
		}
	}
}
