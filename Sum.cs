using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sum : MonoBehaviour
{
    // 7 shared variables
    public static int start_counter;
    public static int finish_A;
    public static int finish_B;
    public static int fail_A;
    public static int fail_B;
    public static double timestamp;
    public static double start_time;
    public static double total_time;
    public static Text text;  // really changes the canvas

    void Start()
    {
        // initialize
        start_counter = 0;
        finish_A = 0;
        finish_B = 0;
        fail_A = 0;
        fail_B = 0;
        timestamp = 1.0;
        start_time = 0.0;
        total_time = 0.0;
        text = transform.Find("Text").GetComponent<Text>();
        text.text = "";
    }

    // used as the timestamp
    void FixedUpdate()
    {
        // the only one who updates the timestamp
        timestamp += 1.0;
        total_time = (timestamp - start_time) * 0.02;

        // show the timer in the sky
        if (start_time != 0.0)
        {
            text.text = total_time.ToString("F2");
        }
    }
}

