using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isVisible : MonoBehaviour {

    public float DestructionTime = 2.0f;
    float Time = 0.0f;
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<Renderer>().isVisible)
        {
            Debug.Log("Visible");
            Time++;
            if(Time == DestructionTime)
            {
                Destroy(gameObject);
                Debug.Log("Disappearing");
            }
            
        }
        else
        {
            print("Not Visible");
        }


    }
}
