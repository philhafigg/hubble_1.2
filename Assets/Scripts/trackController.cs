using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public interface trackController: Trackable
{
    // Start extended tracking. The Target can be tracked although it is not visible.
    bool StartExtendedTracking();

    // Stop extended tracking. Target will only be tracked when it is visible.
    bool StopExtendedTracking();
}