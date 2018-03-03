using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    public EventManager eventOut;
    public EventManager eventIn;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        eventIn.gameObject.SetActive(true);
        eventIn.Activate();
        eventOut.gameObject.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        eventIn.gameObject.SetActive(false);
        eventOut.gameObject.SetActive(true);
        eventOut.Activate();
    }
}