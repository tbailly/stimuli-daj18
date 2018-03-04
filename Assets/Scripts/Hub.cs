using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : MonoBehaviour {

    public GameObject interior;
    public GameObject exterior;
    public GameManager gameManager;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        exterior.SetActive(false);
        interior.SetActive(true);
        gameManager.isInterior = true;
    }

    public Vector3 RotateAround(float distance)
    {
        float angle = Random.Range(0.0f, Mathf.PI * 2);
        Vector3 V = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        V *= distance;
        return V;
    }
}
