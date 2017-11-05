using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API : MonoBehaviour {

	public WWWForm form;
	public WWW w;

	// Use this for initialization
	IEnumerator Start () {
		//WWWForm form = new WWWForm();
		//var headers = form.headers;
		//form.headers["Method"] = "GET";
		//form.headers["apikey"] = "bIDOZ5Sz2ELuhUEMIMUtKl23xAzvPBeV";
		//form.headers["Accept"] = "applicaton/json";
		//form.headers["lat"] = "32";
		//form.headers ["long"] = "32";
		w = new WWW("https://apis.solarialabs.com/shine/v1/parking-rules/meters?lat=37.7749&long=-122.4194&apikey=bIDOZ5Sz2ELuhUEMIMUtKl23xAzvPBeV");
		yield return w;
		if (w.error == null) {
			Debug.Log (w.text); 
		} else {
			Debug.Log (w.error);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.LogWarning ("hi" + w.text);
		
	}


}
