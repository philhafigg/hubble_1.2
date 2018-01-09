using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiTouchedAnimation : MonoBehaviour {

    public GameObject fadeObj;
    public GameObject activeObj;

    private float slow = 0.7f;
    private bool isLerp = false;
    float _timeStartedLerping;
    private Color fadeColor;

    private Color activeColor;
    private float timeToFade = 10.0f;
    private float actTime = 0;
    private Vector2 rt = new Vector2(160, 160);

    public bool selected;


    // Use this for initialization
    void Start () {

        fadeColor = fadeObj.GetComponent<Image>().color;
        fadeColor.a = 0;

        activeColor = fadeObj.GetComponent<Image>().color;
        activeColor.a = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        actTime += Time.deltaTime / timeToFade;

        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / slow;


            fadeObj.SetActive(true);
            fadeObj.GetComponent<Image>().color = Color.Lerp(fadeObj.GetComponent<Image>().color, fadeColor, actTime);
            fadeObj.GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(fadeObj.GetComponent<RectTransform>().sizeDelta, rt, actTime);

            if (fadeObj.GetComponent<Image>().color.a <= 0.6f) {

                activeObj.GetComponent<Image>().color = Color.Lerp(activeObj.GetComponent<Image>().color, activeColor, actTime);
                activeObj.SetActive(true);
            }

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
            }

            /*
            if (fadeObj.GetComponent<Image>().color.a <= 0.1f)
            {

                fadeColor.a = 1.0f;
                fadeObj.GetComponent<Image>().color = fadeColor;
                fadeColor.a = 0.0f;
                fadeObj.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 120);
                fadeObj.SetActive(false);
                actTime = 0;
                canFade = false;
            }
            */
        }

        if (selected == false) {

            activeObj.SetActive(false);
        }
    }

    public void Touched()
    {
        _timeStartedLerping = Time.time;
        selected = true;
        isLerp = true;


    }
}
