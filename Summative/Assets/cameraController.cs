using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public float movingSpeed;
    public float zoomingSpeed;

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        movePo();
        moveRo();
        zoom();
    }

    private void movePo()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 m = transform.right * movingSpeed * Time.deltaTime;
            this.transform.Translate(m);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 m = transform.right * -1 * movingSpeed * Time.deltaTime;
            this.transform.Translate(m);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 m = transform.up * -1 * movingSpeed * Time.deltaTime;
            this.transform.Translate(m);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 m = transform.up * movingSpeed * Time.deltaTime;
            this.transform.Translate(m);
        }
    }

    private void moveRo()
    {
        if(Input.GetMouseButton(1))
        this.transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -1f, Input.GetAxis("Mouse X") * 1f, 0);
    }

    private void zoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Vector3 m = transform.forward * zoomingSpeed * Time.deltaTime;
            gameObject.transform.Translate(m);
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            Vector3 m = transform.forward*-1 * zoomingSpeed * Time.deltaTime;
            gameObject.transform.Translate(m);
        }

    }
}
