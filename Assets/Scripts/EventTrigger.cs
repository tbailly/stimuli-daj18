using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    public GameObject eventOut;
    public GameObject eventIn;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (eventOut.activeSelf == true)
        {
            eventIn.SetActive(true);
            eventOut.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        eventIn.SetActive(false);
    }
}