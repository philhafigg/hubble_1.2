using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class GuiControll : MonoBehaviour
{

    private GameObject[] buttonList;
    public GameObject activeButton;
    public GameObject activeSection;
    public GameObject[] sectionList;
    public GameObject mainController;


    // Use this for initialization
    void Start()
    {
        getAllButtons();
        getAllSections();
    }

    void getAllSections()
    {

        sectionList = GameObject.FindGameObjectsWithTag("GUI_Section");

        foreach (GameObject section in sectionList)
        {
           // section.SetActive(false);
        }
    }

    void getAllButtons()
    {

        buttonList = GameObject.FindGameObjectsWithTag("GUI_Button");

        foreach (GameObject button in buttonList)
        {

            button.GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GUI").GetComponent<GuiControll>().buttonPushed(button));
        }
    }

    void buttonPushed(GameObject button)
    {

        if (activeButton)
        {

            activeButton.GetComponent<guiTouchedAnimation>().selected = false;
        }

        button.GetComponent<guiTouchedAnimation>().selected = true;
        activeButton = button;

        activateElement();
    }

    void activateElement() {

        string[] substrings = activeButton.name.Split(new string[] { "Button_" }, StringSplitOptions.None);
        mainController.GetComponent<mainController>().activateElement(substrings[1]);
    }

    public void activateSection(String section) {
        
        //if (section != activeSection.transform.name) {

            if (activeSection) {

                activeSection.transform.Find("ButtonChildren").GetComponent<Animator>().SetTrigger("closeChildAnimation");
                //activeSection.SetActive(false);
            }

            activeSection = gameObject.transform.Find(section).gameObject;

            activeSection.SetActive(true);
            activeSection.GetComponentInChildren<lerpUIPosition>().blend();

       // }
    }

    public void deactivateSection(){
        if (activeSection)
        {
            activeSection.transform.FindDeepChild("ButtonChildren").gameObject.GetComponent<Animator>().SetTrigger("closeChildAnimation");
                         //GetComponentInChildren<resetChildAnimationMovement>()
            //activeSection.SetActive(false);
            activeSection = null;
        }
    }
}