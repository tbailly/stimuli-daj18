using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSkybox : MonoBehaviour {

    public Material mat;   
    private Color baseColor;
    public Color newColor;
    private float baseExposure;
    public float newExposure;
    public float durationFade;

    private Color lerpedColor = Color.white;
    private float lerpedExposure;
    private float t = 0f;  

    public void Start()
    {
        baseColor = mat.GetColor("_Tint");
        baseExposure = RenderSettings.skybox.GetFloat("_Exposure");
    }
    private void Update()
    {                   
        lerpedColor = Color.Lerp(baseColor, newColor, t);
        lerpedExposure = Mathf.Lerp(baseExposure, newExposure, t);

        t += Time.deltaTime / durationFade;
        mat.SetColor("_Tint", lerpedColor);
        RenderSettings.skybox.SetFloat("_Exposure", lerpedExposure);
    }  
}
