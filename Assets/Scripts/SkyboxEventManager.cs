using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxEventManager : MonoBehaviour {
   
    private Color baseColor;
    public Color newColor;
    public Material mat;
    public float durationFade;

    private Color lerpedColor = Color.white;
    private float t = 0f;

    private bool trigger = false;

    public void Start()
    {
        mat.SetColor("_Tint", lerpedColor);
    }
    private void Update()
    {
        if (trigger)
        {           
            lerpedColor = Color.Lerp(baseColor, newColor, t);
            t += Time.deltaTime / durationFade;
            mat.SetColor("_Tint", lerpedColor);

            if (t >= 1)
                trigger = false;
        }
    }

    public void Activate()
    {
        baseColor = mat.GetColor("_Tint");        
        trigger = true;
    }    
}
