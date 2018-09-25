using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoltageChanged : MonoBehaviour {

    public Slider battSlider;
    public InputField ipf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string XXX = (battSlider.value).ToString();
        ipf.text = XXX + " V";
	}
}
