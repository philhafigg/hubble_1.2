using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimation : MonoBehaviour {

    public void PlayAnimation() {

        gameObject.GetComponent<Animation>().Play();

    }
}
