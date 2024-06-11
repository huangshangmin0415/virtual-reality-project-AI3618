using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public static Text text_star;  // really changes the canvas

    void Start()
    {
        text_star = transform.Find("Text").GetComponent<Text>();
        text_star.text = "";
    }

    // used as the timestamp
    void FixedUpdate()
    {

    }
}

