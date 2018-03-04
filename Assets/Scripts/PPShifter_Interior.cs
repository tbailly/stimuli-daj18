using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;


public class PPShifter_Interior : MonoBehaviour
{

    public PostProcessingProfile PPPremiere_Phase;
    public PostProcessingProfile PPInterior;
    public Player player;
    private bool Interior = false;

    public void OnTriggerEnter(Collider col)

    {
        if (col.gameObject.tag == "Player")
            Interior = !Interior;
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Interior)
            player.GetComponentInChildren<PostProcessingBehaviour>().profile = PPInterior;
        else
            player.GetComponentInChildren<PostProcessingBehaviour>().profile = PPPremiere_Phase;
    }
}

