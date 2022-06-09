using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicSwitching : MonoBehaviour
{

    public AudioSource source;
    public AudioClip[] clips;
    private bool isNearJukeBox = false;
    private int currentClip = 0;

    void Start()
    {
        source.clip = clips[currentClip];
        source.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNearJukeBox = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearJukeBox = false;
    }

    void Update()
    {
        if (isNearJukeBox && Input.GetKeyDown(KeyCode.Q))
        {
            if (currentClip + 1 >= clips.Length)
            {
                currentClip = 0;
            }
            else
            {
                currentClip += 1;
            }
            source.clip = clips[currentClip];
            source.Play();
        }
    }
}
