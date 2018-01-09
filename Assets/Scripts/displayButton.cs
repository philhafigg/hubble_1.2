using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayButton : MonoBehaviour
{

    public void hideButton()
    {

        gameObject.SetActive(false);
    }

    public void showButton()
    {

        gameObject.SetActive(true);
    }
}
