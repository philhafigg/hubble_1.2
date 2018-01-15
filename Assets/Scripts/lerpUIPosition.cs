using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lerpUIPosition : MonoBehaviour {

    public GameObject GUI, buttonChildren;
    public Vector2 startPos, endPos, actPos;
    public Rect startRect, endRect, actRect;

    public bool startCenter = false;
    public float slow = 10f;
    float _timeStartedLerping;
    public bool isLerp = false;
    public bool isScale = false;
    ScreenOrientation actRotation;

    Rect rect;
    Vector2 offset = new Vector2(100, 100);

    // Use this for initialization
    void Start () {
        actRotation = Screen.orientation;


        if (startCenter) {

            startPos = new Vector2(0,0) ;

        }

        gameObject.GetComponent<RectTransform>().anchoredPosition = startPos;
	}

    void Update()
    {
        if (Screen.orientation != actRotation) {

            updatePosition();
        }    
    }

    void FixedUpdate() {
        
        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted * slow;
            
            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startPos, endPos, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                isLerp = false;
                buttonChildren.GetComponent<Animator>().SetTrigger("childAnimationMovement");
            }
        }
    }
 
    public void blend()
    {

        rect = GUI.GetComponent<RectTransform>().rect;
        endPos = new Vector2((rect.width / 2) - offset.x, ((rect.height / 2) - offset.y) * -1);

        gameObject.GetComponent<Animator>().SetTrigger("animationScale");
        StartCoroutine(startLerping());
    }

    IEnumerator startLerping()
    {

        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Animator>().SetTrigger("animationScale");
        _timeStartedLerping = Time.time;
        isLerp = true;
    }

    void updatePosition() {

        rect = GUI.GetComponent<RectTransform>().rect;
        endPos = new Vector2((rect.width / 2) - offset.x, ((rect.height / 2) - offset.y) * -1);
        gameObject.GetComponent<RectTransform>().anchoredPosition = endPos;

        actRotation = Screen.orientation;
    }

}
