using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;


//access user's camera and set focus
public class focusCamera : MonoBehaviour
{

    // Use this for initialization

    void Start()
    {

        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);

        //CameraDevice.Set
    }

    void OnVuforiaStarted() {

        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
    /*
    private void Update()
    {
       
        if (Input.GetMouseButtonUp(0) && !Input.touchSupported)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.transform ) {

                    CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
                    CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
                }
            }
        }
        else if (Input.touchSupported && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {

                if (!hit.transform)
                {

                    CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
                    CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
                }

            }
        }

    }*/
}
