using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSkybox : MonoBehaviour {

    public Material mat;
    public Material backup;
    private Color baseColor;
    public Color newColor;
    private float baseExposure;
    public float newExposure;
    public float durationFade;

    private Color lerpedColor = Color.white;
    private float lerpedExposure;
    private float t = 0f;  

    void Awake()
    {
        baseColor = backup.GetColor("_Tint");
        baseExposure = backup.GetFloat("_Exposure");
        RenderSettings.skybox.SetFloat("_Exposure", baseExposure);
        mat.SetColor("_Tint", baseColor);
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
