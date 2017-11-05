using UnityEngine;
using System.Collections;
using UnityEngine.Windows;

public class ShowImageOnPanel : MonoBehaviour {

    public GameObject ImageFrameObject; // The object to place the image on
	public GameObject ImageFrameObject2;

	// Use this for initialization
	void Start () {
		StartCoroutine (DisplayImage ());
	}
	
	// Update is called once per frame
	void Update () {

        // Replace this block of code with how you plan to call your image display
	    /*if(Input.GetKeyDown(KeyCode.P))
        {
            DisplayImage();
        }*/
	} 

	IEnumerator DisplayImage()
    {
		yield return new WaitForSeconds(1);
        Texture2D imageTxtr = new Texture2D(2, 2);
		Texture2D imageTxtr2 = new Texture2D(2, 2);
        string fileName = gameObject.GetComponent<ImageToComputerVisionAPI>().fileName;
		string fileName2 = gameObject.GetComponent<ImageToComputerVisionAPI>().fileName2;
		byte[] fileData = System.IO.File.ReadAllBytes(fileName);
		byte[] fileData2 = System.IO.File.ReadAllBytes(fileName2);
        imageTxtr.LoadImage(fileData);
		imageTxtr2.LoadImage(fileData2);
        ImageFrameObject.GetComponent<Renderer>().material.mainTexture = imageTxtr;
		ImageFrameObject2.GetComponent<Renderer>().material.mainTexture = imageTxtr2;
    }
}
