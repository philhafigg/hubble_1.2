using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetChildAnimationMovement : MonoBehaviour {

    Component[] imageList;
    Component[] transformList;


    private void Start()
    {
        imageList = gameObject.transform.GetComponentsInChildren<Image>();
        transformList = gameObject.transform.GetComponentsInChildren<RectTransform>();
    }

    public void ResetChildAnimationMovement() {

        foreach (Image tImage in imageList) {

            tImage.color = new Color(1, 1, 1, 0);
        }

        foreach (RectTransform tTransform in transformList)
        {

            tTransform.anchoredPosition = new Vector2(0, 0);
        }
    }
	

}	