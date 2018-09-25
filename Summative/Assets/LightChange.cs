using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightChange : MonoBehaviour {

    public Slider waveLength;
    public Slider Intensity;
    public Light li;

    private float r;
    private float g;
    private float b;
    private float w;
    private float[] rgb = new float[3];

	// Use this for initialization
	void Start () {
        //li = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        Convert();
        //changeColor();
	}

    private float[] Convert()
    {
        w = (int)waveLength.value;

        if ((w >= 380) && (w < 450))
        {
            r = -(w - 450) / (450 - 380);
            g = 0f;
            b = 1f;
        }
        else if ((w >= 450) && (w < 495))
        {
            r = 0f;
            g = (w - 450) / (495 - 450);
            b = 1f;
        }
        else if ((w >= 495) && (w < 570))
        {
            r = 0f;
            g = 1f;
            b = -(w - 570) / (570 - 495);
        }
        else if ((w >= 570) && (w < 590))
        {
            r = (w - 570) / (590 - 570);
            g = 1f;
            b = 0f;
        }
        else if ((w >= 590) && (w < 620))
        {
            r = 1f;
            g = -(w - 620) / (620 - 590);
            b = 0f;
        }
        else if ((w >= 620) && (w < 750))
        {
            r = 1f;
            g = 0f;
            b = 0f;
        }
        else
        {
            r = 0;
            g = 0;
            b = 0;
        }

        rgb[0] = r;
        rgb[1] = g;
        rgb[2] = b;

        return rgb;
    }

    public void changeColor()
    {
        li.color = new Color(rgb[0], rgb[1], rgb[2],255f);
    }

    public void changeIntensity()
    {
        li.intensity = (Intensity.value/100)*8;
    }

}
