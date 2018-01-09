using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blendInOut : MonoBehaviour {

    private float endAlpha, startAlpha;

    Color tColor, startColor, endColor;
    public float slow = 0.7f; 
    float _timeStartedLerping;
    bool isLerp = false;
    public Component[] renderers;

    // Use this for initialization
    void Start () {

        renderers = gameObject.GetComponentsInChildren<Renderer>();
        startAlpha = tColor.a;  
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted;

            foreach (Renderer renderer in renderers)
            {
                tColor = renderer.material.color;
            
                startColor = new Color(tColor.r, tColor.g, tColor.b, startAlpha);
                endColor = new Color(tColor.r, tColor.g, tColor.b, endAlpha);

                renderer.material.color = Color.Lerp(startColor, endColor, percentageComplete / slow);
            }

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
            }
        }
    }
    //1 is in 0 is out
    public void blend(bool blendMode) {

        if (blendMode)
        {
            startAlpha = 0.0f;
            endAlpha = 1.0f;
        }
        else {
            startAlpha = 1.0f;
            endAlpha = 0.0f;
        }

        isLerp = true;
        _timeStartedLerping = Time.time;
        
    }
}
