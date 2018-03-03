using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTimer : MonoBehaviour {

    public float value_max;
    private float value_min;

	void Start () {
        value_min = Time.deltaTime;
	}
	

	void Update () {
        value_min += Time.deltaTime;
       
        if(value_min >= value_max)
        {
            Debug.Log("End of the game");
        }
        else
        {
            
        }
	}
}
