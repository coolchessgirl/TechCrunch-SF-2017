using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour {

	public Toggle birdsEye;
	public GameObject camera1;
	public GameObject camera2;
	public OVRCameraRig c1;
	public OVRCameraRig c2;
	public Text text;
	//public GameObject camera1parent;
	// Use this for initialization
	void Start () {
		birdsEye.enabled = false;
		c1.enabled = true;
		c2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		text.text = OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote).ToString ()
		+ "\nC=" + OVRInput.GetActiveController ().ToString () + "<<" + OVRInput.GetConnectedControllers () + "<<";

		Debug.Log ("JJJJJJJJJJJJJJ" + text.text + "JJJJJJJJ");
		if (birdsEye.isOn) {
			c1.enabled = true;
			c2.enabled = false;
			if (Input.GetKey ("up") || OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote).x < 0)
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
			if (Input.GetKey ("up") || OVRInput.Get (OVRInput.Axis2D.PrimaryTouchpad, OVRInput.Controller.RTrackedRemote).x < 0) {
				camera2.transform.Translate (Vector3.forward * Time.deltaTime * 100);
				Debug.Log ("hi");
			}
			if (Input.GetKey ("down"))
				camera2.transform.Translate (Vector3.back * Time.deltaTime * 100);
			if (Input.GetKey ("left"))
				camera2.transform.Rotate (Vector3.down * Time.deltaTime * 100);
			if (Input.GetKey ("right"))
				camera2.transform.Rotate (Vector3.up * Time.deltaTime * 100);
		}
	}
}
