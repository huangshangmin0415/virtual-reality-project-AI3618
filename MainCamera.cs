using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    private AudioSource[] audio_list;
    private AudioSource audio_finish;
    private AudioSource audio_fail;
    private AudioSource audio_bgm;
    int is_playing_finish;
    int is_playing_fail;

    void Start()
    {
        audio_list = gameObject.GetComponents<AudioSource>();
        audio_finish = audio_list[0];
        audio_fail = audio_list[1];
        audio_bgm = audio_list[2];
        is_playing_finish = 0;
        is_playing_fail = 0;

        audio_bgm.Play();
    }

    void FixedUpdate()
    {
        if (Sum.finish_A > 0 && Sum.finish_B > 0)
        {
            is_playing_finish++;
            if (is_playing_finish == 2)
            {
                audio_finish.Play();
            }
        }

        if ((Sum.finish_A > 0 && Sum.fail_B > 0) || (Sum.finish_B > 0 && Sum.fail_A > 0))
        {
            is_playing_finish++;
            if (is_playing_finish == 2)
            {
                audio_finish.Play();
            }
        }

        if (Sum.fail_A > 0 && Sum.fail_B > 0)
        {
            is_playing_fail++;
            if (is_playing_fail == 2)
            {
                audio_finish.Stop();
                audio_fail.Play();
            }
        }

        if (is_playing_fail == 600 || is_playing_finish == 1000)
        {
            SceneManager.LoadScene(0);
        }
    }
}

