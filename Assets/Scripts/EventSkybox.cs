using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSkybox : MonoBehaviour {

    public Material mat;   
    private Color baseColor;
    public Color newColor;  
    public float durationFade;

    private Color lerpedColor = Color.white;
    private float t = 0f;  

    public void Start()
    {
        baseColor = mat.GetColor("_Tint");     
        
    }
    private void Update()
    {                   
        lerpedColor = Color.Lerp(baseColor, newColor, t);
        t += Time.deltaTime / durationFade;
        mat.SetColor("_Tint", lerpedColor);        
    }  
}
