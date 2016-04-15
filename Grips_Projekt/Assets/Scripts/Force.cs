using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W)) {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 3, ForceMode.VelocityChange);
        }

        
	}
}
