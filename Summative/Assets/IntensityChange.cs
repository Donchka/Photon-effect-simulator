using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntensityChange : MonoBehaviour {

    public Slider Intenslider;
    public InputField Ip;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ip.text = Intenslider.value.ToString() + " %";
	}

    public void adjustInten()
    {
        //Intenslider.value = int.Parse(Ip.text.Split(' '));
    }

}
