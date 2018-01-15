using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScreen : MonoBehaviour {

    public void RotateScreen()
    {

        if (Screen.orientation == ScreenOrientation.LandscapeLeft) {

            Screen.orientation = ScreenOrientation.Portrait;
        } else {

            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
