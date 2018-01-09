using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleButton : MonoBehaviour
{

    private bool mTrackerON = true;
    private bool mWasPaused = false;
    public bool togglebutton;
    public GameObject ButtonPlay;
    public GameObject ButtonPause;

    // Use this for initialization
    void Start()
    {
        ButtonPlay.SetActive(false);
        ButtonPause.SetActive(true);
    }

    void OnApplicationPause(bool b)
    {
        Debug.Log("====== App was Paused ======");
        mWasPaused = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (mWasPaused)
        {
            // updating after it was paused
            // this means we have just resumed
            Debug.Log("====== App was just resumed ===== ");

            if (!mTrackerON)
            {
                CameraDevice.Instance.Stop();
                ObjectTracker imgTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                imgTracker.Stop();
                Debug.Log("======  Force Stop ARCamera and Trackers ======");
            }
            mWasPaused = false;
        }
    }

    public int counter = 0;
    public void ChangeButton()
    {
        counter++;
        if (counter % 2 == 1 && togglebutton == false)
        {
            CameraDevice.Instance.Stop();
            ObjectTracker imgTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            imgTracker.Stop();
            togglebutton = true;
            mTrackerON = false;
            ButtonPlay.SetActive(true);
            ButtonPause.SetActive(false);
        }
        else
        {
            if (togglebutton == true)
            {
                CameraDevice.Instance.Start();
                ObjectTracker imgTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
                imgTracker.Start();
                togglebutton = false;
                mTrackerON = true;
                ButtonPlay.SetActive(false);
                ButtonPause.SetActive(true);
            }
        }
    }
}