using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ImageToComputerVisionAPI : MonoBehaviour {

	string VISIONKEY = "cf7ba25b351243489d92450c208df868"; // replace with your Computer Vision API Key

	string emotionURL = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze";

    public string fileName { get; private set; }
	public string fileName2 { get; private set; }
    string responseData;
	string responseData2;

    // Use this for initialization
    void Start () {
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name == "fire") {
			fileName = Path.Combine (Application.streamingAssetsPath, "fire.jpg");
			fileName2 = Path.Combine (Application.streamingAssetsPath, "fire2.jpg");

		}
		else{
	    	fileName = Path.Combine(Application.streamingAssetsPath, "bread.jpg"); // Replace with your file
			fileName2 = Path.Combine(Application.streamingAssetsPath, "apple.jpg"); // Replace with your file
		}
		StartCoroutine(GetVisionDataFromImages());
    }
	
	// Update is called once per frame
	void Update () {
	
        // This will be called with your specific input mechanism
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
            
        //}

	}
    /// <summary>
    /// Get emotion data from the Cognitive Services Emotion API
    /// Stores the response into the responseData string
    /// </summary>
    /// <returns> IEnumerator - needs to be called in a Coroutine </returns>
    IEnumerator GetVisionDataFromImages()
    {
		
		byte[] bytes = System.IO.File.ReadAllBytes(fileName);
		byte[] bytes2 = System.IO.File.ReadAllBytes(fileName2);

        var headers = new Dictionary<string, string>() {
            { "Ocp-Apim-Subscription-Key", VISIONKEY },
            { "Content-Type", "application/octet-stream" }
        };

        WWW www = new WWW(emotionURL, bytes, headers);
        yield return www;

		WWW www2 = new WWW(emotionURL, bytes2, headers);
		yield return www2;

        responseData = www.text; // Save the response as JSON string
		responseData2 = www2.text; // Save the response as JSON string
		Debug.Log(responseData);
		Debug.Log (responseData2);
		//GetComponent<ParseComputerVisionResponse> ().ParseJSONData (responseData);
    }
}
