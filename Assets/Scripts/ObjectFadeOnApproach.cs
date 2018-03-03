using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeOnApproach : MonoBehaviour {

    public Player player;
    public float startFadeDistance;
    public float endFadeDistance;

    MeshRenderer rend;
    Material mat;

	// Use this for initialization
	void Start () {
        rend = GetComponent<MeshRenderer>();
        mat = rend.material;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < startFadeDistance && distance > endFadeDistance)
        {
            if (rend.enabled == false)
                rend.enabled = true;
            float alpha = (distance - endFadeDistance) / (startFadeDistance - endFadeDistance);
            Color oldColor = mat.color;
            mat.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
        }
        else if (distance <= endFadeDistance && rend.enabled == true)
            rend.enabled = false;
        else if (distance >= startFadeDistance && rend.enabled == false)
            rend.enabled = true;
    }
}
