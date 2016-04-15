using UnityEngine;
using System.Collections;
using System;

public class AmmoTrigger : MonoBehaviour {

    private float minValue = 1.5f;
    private float maxValue = 3.5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        animateIcon();
    }

    private void animateIcon()
    {
        //Rotation
        transform.Rotate(Vector3.up);

        //Pulsate
        float sin = (maxValue - minValue) * Mathf.Abs(Mathf.Cos(Time.realtimeSinceStartup));
        float factor = minValue + sin;
        transform.localScale = Vector3.one * factor;
    }
}
