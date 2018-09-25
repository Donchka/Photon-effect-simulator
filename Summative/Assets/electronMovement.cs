using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class electronMovement : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Death();
	}

public void Death(){

        if (gameObject.transform.position.x >= 24.49f||gameObject.transform.position.x<=12.56f)
        {
            Manager.removeEle(gameObject);
            Destroy(gameObject);
        }
    }

    public void Death(float nothing)
    {
        Manager.removeEle(gameObject);
        Destroy(gameObject);
    }
}
