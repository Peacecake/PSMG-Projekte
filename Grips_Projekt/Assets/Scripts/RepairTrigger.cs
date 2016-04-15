using UnityEngine;
using System.Collections;
using System;

public class RepairTrigger : MonoBehaviour {

    private float minValue = 10f;
    private float maxValue = 30f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        animateIcon();
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Component in same gameObject
            gameObject.GetComponent<RepairTrigger>().enabled = false;
        }

       
        
	}

    private void animateIcon()
    {
        //Rotation
        transform.Rotate(Vector3.up);

        //Pulsate
        float sin = (maxValue - minValue) * Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup));
        float factor = minValue + sin;
        transform.localScale = Vector3.one * factor;
    }
}
