using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;


public class PPShifter_Interior : MonoBehaviour
{

    public PostProcessingProfile PPPremiere_Phase;
    public PostProcessingProfile PPPhase2;
    public PostProcessingProfile PPPhase3;
    public Player player;
    private bool Interior = false;
    private float TimeToShift = 0.0f;
    public float TimePPPhase2 = 60.0f;
    public float TimePPPhase3 = 120.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TimeToShift += Time.deltaTime;

        if (TimeToShift > TimePPPhase2 && TimeToShift < TimePPPhase3)
            player.GetComponentInChildren<PostProcessingBehaviour>().profile = PPPhase2;
        else if (TimeToShift > TimePPPhase3)
            player.GetComponentInChildren<PostProcessingBehaviour>().profile = PPPhase3;
        else
            player.GetComponentInChildren<PostProcessingBehaviour>().profile = PPPremiere_Phase;
    }
}

