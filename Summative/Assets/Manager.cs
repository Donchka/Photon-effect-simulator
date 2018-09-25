using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public static List<GameObject> electrons;
    public GameObject singledog;


    [HideInInspector]public float WF;
    [HideInInspector]public Rigidbody eleRigibody;
    public Slider WL;
    public Slider IN;
    public Slider BA;
    public float forceScale;
    public int MaxElectron; 

    private float h = 6.626f * (Mathf.Pow(10f, -34f));
    private float c = 3 * (Mathf.Pow(10f, 8f));
    private float ev = 1.60f * (Mathf.Pow(10, -19));
    private float mass = 9.10938356f * (Mathf.Pow(10, -31));
    private float thresholdWL;
    private float frequency;
    private float Ek;
    private float Ekev;
    private float stopPoint;
    private float speed;//1 to 7
    private bool comeout=false;
    private bool need;
    private float generateRate;//0.1 0.3 0.5

    private float MinY = 8.426f;
    private float MaxY = 11.47f;
    private float MinZ = 24.67f;
    private float MaxZ = 28.14f;
    private float MinSpeed;//ideal lowest = 30
    private float MaxSpeed;//ideal highest = 185
    

    // Use this for initialization
    void Start () {
        electrons = new List<GameObject>();
        InvokeRepeating("spawnElectrons", 0f, 0.05f);
    }
	
	// Update is called once per frame
	void Update () {
        if (need)
        {
            CancelInvoke();
            InvokeRepeating("spawnElectrons", 0f, generateRate);
            need = false;
        }
        //Debug.Log(speedAndrate());
        calculateComeout();
        //spawnElectrons(comeout);
        //StartCoroutine(create());
    }

    private void FixedUpdate()
    {
        if (electrons.Count >= MaxElectron)
        {
            Debug.Log(electrons.Count);
            electrons[0].GetComponent<electronMovement>().Death(h);
        }

        foreach(GameObject e in electrons)
        {
            
            //if (e == null)
            //{
            //    electrons.Remove(e);
            //    continue;
            //}
            Rigidbody temp = e.GetComponent<Rigidbody>();
            temp.AddForce(new Vector3(forceScale * BA.value, 0f, 0f));
        }
    }

    private bool calculateComeout()
    {
        WF = GetWorkFunction.workFunction;
        frequency = c / (WL.value * Mathf.Pow(10f, -9f));
        Ek = h * frequency - WF * ev;

        if (Ek < 0||IN.value==0)
        {
            comeout = false;
        }
        else if(Ek==0)
        {
            comeout = true;
        }
        else
        {
            comeout = true;
        }     
        //Debug.Log(comeout + " " + WF + "  " + speed + " " + generateRate + " " + MinSpeed);
        //Debug.Log(Mathf.Lerp(30, 185, 0.4f));
        return comeout;
    }

    private void accelerate(bool co,Rigidbody ele)
    {
        if (co)
        {
            speed = Random.Range(MinSpeed,MaxSpeed);
            Vector3 movement = transform.right * speed * Time.deltaTime;
            //ele.MovePosition(ele.position + movement);
            ele.velocity = movement;
        }
        else
        {
            //???
            speed = 30;
            Vector3 movement = transform.right * speed * Time.deltaTime;
            //ele.MovePosition(ele.position + movement);
            ele.velocity = movement;
        }
    }

    private void spawnElectrons()
    {
        if (comeout)
        {
            GameObject Single = Instantiate(singledog, new Vector3(12.66f, Random.Range(MinY, MaxY), Random.Range(MinZ, MaxZ)), Quaternion.Euler(0,90,0));
            eleRigibody = Single.GetComponent<Rigidbody>();
            eleRigibody.detectCollisions = false;
            speedAndrate(eleRigibody);
            accelerate(comeout,eleRigibody);
            electrons.Add(Single);
        }
    }

    private float speedAndrate(Rigidbody elect)
    {
        calculateThresholdWL();
        float diff1 = thresholdWL - 281;
        float diff2 = thresholdWL - WL.value;

        float factor = diff2 / diff1;
        float factorIn = IN.value / 100;
        float rrr = Random.Range(1f, 2f);

        generateRate = Mathf.Lerp(0.05f, 0.5f, 1-factor);
        generateRate = Mathf.Lerp(generateRate,rrr,1-factorIn);
        MinSpeed = Mathf.Lerp(30, 85, factor);
        //Debug.Log(MinSpeed + " " + generateRate);
        //potential(elect);
        MaxSpeed = MinSpeed + 10;

        //Debug.Log(diff2);
        if (Mathf.Floor(diff2) == 0){
            MinSpeed = MaxSpeed = 0;
        }

        return generateRate;
    }

    private void calculateThresholdWL()
    {
        thresholdWL = (c / (WF * ev / h))*Mathf.Pow(10,9);
    }

    public void needUpdate()
    {
        need = true;
    }

    private void potential(Rigidbody elec)
    {
        Ekev = Ek / ev;
        Debug.Log(Ekev);
        if (Ekev < BA.value)
        {        
            float factor3 = Ekev / BA.value;//11.83
            stopPoint = 12.66f + 11.83f * factor3;//stop point for transform.x
            float diff3 = stopPoint - elec.transform.position.x;
            float factor4 = diff3 / (stopPoint - 12.66f);
            MinSpeed = Mathf.Lerp(0f, MinSpeed, factor4);
            Debug.Log(stopPoint + " " + MinSpeed);
        }
    }

     public static void removeEle(GameObject eleee)
    {
        electrons.Remove(eleee);
    }
   
}
