using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFadeOnApproach : MonoBehaviour
{

    public Player player;
    public ControllerManager controllerManager;
    public float p1;
    public float p2;
    public float p3;
    public float p4;

    MeshRenderer rend;
    Material mat;
    Vector3 vectorToPlayer;

    // Use this for initialization
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player)); 
        controllerManager = (ControllerManager)FindObjectOfType(typeof(ControllerManager)); 
        rend = GetComponent<MeshRenderer>();
        mat = rend.material;
        vectorToPlayer = transform.position - player.transform.position;
        vectorToPlayer.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Color oldColor = mat.color;

        mat.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
        if (distance < p3 - 1 && distance > p4)
        {
            if (rend.enabled == false)
                rend.enabled = true;
            float alpha = (distance - p4) / (p3 - p4);
            mat.color = new Color(oldColor.r, oldColor.g, oldColor.b, alpha);
        }
        else if (distance >= p2 && distance < p1)
        {
            if (rend.enabled == false)
                rend.enabled = true;
            float alpha = (distance - p2) / (p1 - p2);
            mat.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1 - alpha);
        }
        else if ((distance <= p4 && rend.enabled == true) ||
                (distance >= p1 && rend.enabled == true))
        {
            rend.enabled = false;
        }
        else if (distance >= p3 && distance < p2 && rend.enabled == false)
        {
            rend.enabled = true;
        }
    }
}
