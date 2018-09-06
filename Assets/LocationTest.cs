using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationTest : MonoBehaviour {

    Text myText;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        myText.text = string.Concat("Screen Resolution:", Screen.width, ",", Screen.height,
            "\n","Mouse Position:",Input.mousePosition.x,",",Input.mousePosition.y,
            "\n");
	}
    
}
