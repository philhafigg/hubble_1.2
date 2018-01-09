using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothRotation : MonoBehaviour {


    private float rotationsPerMinute = 0.1f;
    float rand;
	// Use this for initialization
	void Start () {



        rand = Random.value;

	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Rotate(6.0f * rotationsPerMinute * Time.deltaTime * rand, rand * 6.0f * rotationsPerMinute * Time.deltaTime, 0);
	}
}


