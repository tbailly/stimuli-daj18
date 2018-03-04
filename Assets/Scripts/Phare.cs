using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phare : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("BeaconRotation");
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator BeaconRotation()
    {
        while(true)
        {
            transform.Rotate(new Vector3(0, 0, 6));
            yield return null;
        }
    }
}
