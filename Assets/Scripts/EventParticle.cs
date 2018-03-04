using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventParticle : MonoBehaviour {

    public ParticleSystem oldParticle;
    public ParticleSystem newParticle;

	void Start () {      
        Destroy(oldParticle.GetComponent<ParticleSystem>());
        newParticle.gameObject.SetActive(true);
	}
	
}
