using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpUIScale : MonoBehaviour {

    public Vector3 startScale, endScale, actScale;
    public float slow = 0.0001f;
    float _timeStartedLerping;
    public bool isLerp = false;

    // Use this for initialization
    void Start () {

        startScale = new Vector2(Screen.width / 2, Screen.height / 2);

          

        gameObject.GetComponent<RectTransform>().localScale = startScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        
        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / slow;
          
            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startScale, endScale, percentageComplete);

            actScale = gameObject.GetComponent<RectTransform>().anchoredPosition;
            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
            }
            
        }
    }

    void blend(Vector2 tPos)
    {
        actScale = startScale;
        endScale = tPos;
        isLerp = true;
        _timeStartedLerping = Time.time;
    }
}
