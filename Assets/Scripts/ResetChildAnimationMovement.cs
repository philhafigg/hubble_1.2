using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetChildAnimationMovement : MonoBehaviour
{


    public GameObject GUI;
    Component[] imageList;
    Component[] transformList;

    private void Start()
    {
        imageList = gameObject.transform.GetComponentsInChildren<Image>();
        transformList = gameObject.transform.GetComponentsInChildren<RectTransform>();
    }

    public void reset()
    {

        foreach (Image tImage in imageList)
        {

            tImage.color = new Color(1, 1, 1, 0);
        }

        foreach (RectTransform tTransform in transformList)
        {

            tTransform.anchoredPosition = new Vector2(0, 0);
        }

        gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

        GUI.GetComponent<GuiControll>().resetSection();
    }


    public void softReset()
    {
        gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}	