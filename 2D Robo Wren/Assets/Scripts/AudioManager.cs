using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource mySource;
    public AudioClip backgroundMusic;
    public float timeSinceStarted = 0.0f;
    public bool startedBackgroudMusic = false;

    void Update () {
        timeSinceStarted += Time.deltaTime;

        if ((timeSinceStarted >= .25f) && (!startedBackgroudMusic)) {
            if (!mySource.isPlaying) {
                mySource.clip = backgroundMusic;
                mySource.loop = true;
                mySource.volume = 0.5f;
                mySource.Play();

                startedBackgroudMusic = true;
            }
        }
	}
}
