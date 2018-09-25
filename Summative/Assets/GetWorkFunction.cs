using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWorkFunction : MonoBehaviour {

    public Dropdown dp;

    private int dpp;
    [HideInInspector]public static float workFunction;
    //public List<electronMovement> LEM;

	// Use this for initialization
	void Start () {
        determine();
	}
	
	// Update is called once per frame
	void Update () {
		//foreach(electronMovement EM in LEM)
  //      {
  //          EM.WF = workFunction;
  //      }
	}

    public void determine()
    {
        dpp = dp.value;

        switch (dpp)
        {
            case 0:
                workFunction = 4.20f;//Al
                break;
            case 1:
                workFunction = 5.1f;//Cu
                break;
            case 2:
                workFunction = 5.1f;//Au
                break;
            case 3:
                workFunction = 4.67f;//Fe
                break;
            case 4:
                workFunction = 4.25f;//Pb
                break;
            case 5:
                workFunction = 3.68f;//Mg
                break;
            case 6:
                workFunction = 5.01f;//Ni
                break;
            case 7:
                workFunction = 2.29f;//K
                break;
            case 8:
                workFunction = 5.64f;//Pt
                break;
            case 9:
                workFunction = 2.36f;//Na
                break;
            case 10:
                workFunction = 4.3f;//Zn
                break;
            case 11:
                workFunction = 2.87f;//Ca
                break;
            case 12:
                workFunction = 1.95f;//Cs
                break;
            case 13:
                workFunction = 4.64f;//Ag
                break;
        }   
    }

}
