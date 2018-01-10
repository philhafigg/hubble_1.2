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
    Rect rect;
    Vector2 offset = new Vector2(100, 100);

    // Use this for initialization
    void Start () {

        Rect rect = GUI.GetComponent<RectTransform>().rect;

        if (startCenter) {

            startPos = new Vector2(0,0) ;
            endPos = new Vector2((rect.width/2) -offset.x , ((rect.height/2) - offset.y )* -1);
        }

        gameObject.GetComponent<RectTransform>().anchoredPosition = startPos;
       // blend();
	}

    void FixedUpdate() {
        
        if (isLerp)
        {

            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted * slow;
            
            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startPos, endPos, percentageComplete);

            if (percentageComplete >= 1.0f)
            {
                Debug.Log("aaaa");
                isLerp = false;
                buttonChildren.GetComponent<Animator>().SetTrigger("childAnimationMovement");
            }
        }
    }
 
    public void blend()
    {
        
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

}
