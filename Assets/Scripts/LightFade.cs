using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{

    public Player player;
    public ControllerManager controllerManager;
    public float p1;
    public float p2;
    public float p3;
    public float p4;

    Vector3 vectorToPlayer;
    Light selfLight;

    // Use this for initialization
    void Start()
    {
        selfLight = GetComponent<Light>();
        vectorToPlayer = transform.position - player.transform.position;
        vectorToPlayer.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < p3 - 1 && distance > p4)
        {
            print("l'intensite");
            if (selfLight.enabled == false)
                selfLight.enabled = true;
            float alpha = (distance - p4) / (p3 - p4);
            selfLight.intensity = alpha * 300;
        }
        else if (distance >= p2 && distance < p1)
        {
            print("l'intensite");
            if (selfLight.enabled == false)
                selfLight.enabled = true;
            float alpha = (distance - p2) / (p1 - p2);
            selfLight.intensity = 300 - alpha * 300;
        }
        else if ((distance <= p4 && selfLight.enabled == true) ||
                (distance >= p1 && selfLight.enabled == true))
        {
            selfLight.enabled = false;
        }
        else if (distance >= p3 && distance < p2 && selfLight.enabled == false)
        {
            selfLight.enabled = true;
        }
    }
}
