using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getInfo : MonoBehaviour {

    public GameObject infoText;
    public int id;
 
    private void OnMouseDown()
    {

        infoText.GetComponentInParent<Transform>();
        List<GameObject> infos = new List<GameObject>();

        for (int i = 0; i < infoText.transform.parent.childCount; i++) {

            GameObject tObj = infoText.transform.parent.GetChild(i).gameObject;
            infos.Add(tObj);
        }

        foreach (GameObject tG in infos)
        {

            tG.SetActive(false);
        }

        infoText.SetActive(true);
    }
}
