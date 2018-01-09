using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchLayers : MonoBehaviour {
    
    private Vector3 startPos, endPos;
    protected bool dragging = false;
    public GameObject layers;
    private int actLayer = 0;
    private int maxLayers;
    private GameObject layer;

	// Use this for initialization
	void Start () {
        layer = gameObject.transform.Find("Layer").gameObject;
        maxLayers = layer.transform.childCount;

        Debug.LogWarning(maxLayers);
	}
	
    private void OnEndDrag() {

        dragging = false;

        if (startPos.x < endPos.x) {
           
            transformOut();

        } else {
            
            transformIn();
        }
    }

    void blendIn() {



        //instant transform on position 0, animate opacity
    }

    void transformIn() {

        if (actLayer != maxLayers) {
            actLayer++;
            GameObject tObj = layer.transform.Find("layer_" + actLayer).gameObject;
            tObj.SetActive(true);
            //tObj.GetComponent<blendIn>().switchObj();
        }



        //instant opacity- animate transform on position 0 


    }

    void transformOut() {

        if (actLayer == 0) return;

        GameObject tObj = layer.transform.Find("layer_" + actLayer).gameObject;
        tObj.SetActive(false);
        //tObj.GetComponent<blendIn>().switchObj();
        actLayer--;


        // animate transform on position x, instant op 0
    }

    private void OnMouseDrag()
    {
        if (!dragging) {

            startPos = Input.mousePosition;
            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        if (dragging) {
            endPos = Input.mousePosition;
            OnEndDrag();
        }

    }
}