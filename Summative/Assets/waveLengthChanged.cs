using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveLengthChanged : MonoBehaviour {

    public Slider WLslider;
    public InputField ip;
    //private Text txt;

	// Use this for initialization
	void Start () {
        //txt = ip.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        ip.text = WLslider.value.ToString();
	}
}
