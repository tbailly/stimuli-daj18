using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSound : MonoBehaviour {

    public float duration;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1;
        StartEventSound();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void StartEventSound()
    {
        if (duration == 0)
            audioSource.loop = false;
        else
        {
            audioSource.loop = true;
            StartCoroutine("StopSoundWithDelay");
        }
        audioSource.Play();
    }

    IEnumerator StopSoundWithDelay()
    {
        yield return new WaitForSeconds(duration);
        audioSource.Stop();
    }
}
