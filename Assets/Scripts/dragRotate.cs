﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragRotate : MonoBehaviour {

    public GameObject hubble;
    float rotSpeed = 10;

    private void OnMouseDrag()
    {

        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        /*
        hubble.transform.RotateAround(Vector3.up, -rotX);
        hubble.transform.RotateAround(Vector3.right, rotY);
        */
    }
}