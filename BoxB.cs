using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxB : MonoBehaviour
{
    // 3 domestic variables
    private AudioSource audio_success;

    void Start()
    {
        // initialize
        audio_success = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // start
        if (collision.gameObject.CompareTag("hands"))
        {
            Sum.start_counter++;

            if (Sum.start_counter == 1)  // touch one box twice will reset the start_time
            {
                Sum.start_time = Sum.timestamp;  // the only one who updates the start time, will not be changed from now on
            }
        }

        // finish
        if (collision.gameObject.CompareTag("finish"))
        {
            audio_success.Play();

            Sum.finish_B++;

            // finish with different levels
            if (Sum.finish_A > 0 && Sum.finish_B > 0)
            {
                Sum.start_time = 0.0;  // no timing

                // Sum.text.text = "You, passed the level!";
                if (Sum.total_time <= 300)
                {
                    Star.text_star.text = "finish within 5 min -- *" + System.Environment.NewLine + 
                                          "finish within 10 min -- *" + System.Environment.NewLine + 
                                          "no box is lost -- *";
                }
                if (Sum.total_time > 300 && Sum.total_time <= 600)
                {
                    Star.text_star.text = "finish within 5 min -- x" + System.Environment.NewLine + 
                                          "finish within 10 min -- *" + System.Environment.NewLine + 
                                          "no box is lost -- *";
                }
                if (Sum.total_time > 600)
                {
                    Star.text_star.text = "finish within 5 min -- x" + System.Environment.NewLine + 
                                          "finish within 10 min -- x" + System.Environment.NewLine + 
                                          "no box is lost -- *";
                }
            }

            if ((Sum.finish_A > 0 && Sum.fail_B > 0) || (Sum.finish_B > 0 && Sum.fail_A > 0))
            {
                Sum.start_time = 0.0;  // no timing

                // Sum.text.text = "You, passed the level!";
                if (Sum.total_time <= 300)
                {   
                    Star.text_star.text = "finish within 5 min -- *" + System.Environment.NewLine + 
                                          "finish within 10 min -- *" + System.Environment.NewLine + 
                                          "no box is lost -- x";
                }
                if (Sum.total_time > 300 && Sum.total_time <= 600)
                {
                    Star.text_star.text = "finish within 5 min -- x" + System.Environment.NewLine + 
                                          "finish within 10 min -- *" + System.Environment.NewLine + 
                                          "no box is lost -- x";
                }
                if (Sum.total_time > 600)
                {
                    Star.text_star.text = "finish within 5 min -- x" + System.Environment.NewLine + 
                                          "finish within 10 min -- x" + System.Environment.NewLine + 
                                          "no box is lost -- x";
                }
            }
        }

        // fail
        if (collision.gameObject.CompareTag("ground"))
        {
            Sum.finish_B = -100;
            Sum.fail_B++;

            if (Sum.fail_A > 0 && Sum.fail_B > 0)
            {
                Sum.start_time = 0.0;  // no timing
                
                // Sum.text.text = "Knocked over, punish!";
            }

            if ((Sum.finish_A > 0 && Sum.fail_B > 0) || (Sum.finish_B > 0 && Sum.fail_A > 0))
            {
                Sum.start_time = 0.0;  // no timing

                // Sum.text.text = "You, passed the level!";
                if (Sum.total_time <= 300)
                {   
                    Star.text_star.text = "finish within 5 min -- *" + System.Environment.NewLine + 
                                          "finish within 10 min -- *" + System.Environment.NewLine + 
                                          "no box is lost -- x";
                }
                if (Sum.total_time > 300 && Sum.total_time <= 600)
                {
                    Star.text_star.text = "finish within 5 min -- x" + System.Environment.NewLine + 
                                          "finish within 10 min -- *" + System.Environment.NewLine + 
                                          "no box is lost -- x";
                }
                if (Sum.total_time > 600)
                {
                    Star.text_star.text = "finish within 5 min -- x" + System.Environment.NewLine + 
                                          "finish within 10 min -- x" + System.Environment.NewLine + 
                                          "no box is lost -- x";
                }
            }
        }
    }

    void FixedUpdate()
    {
        
    }
}
