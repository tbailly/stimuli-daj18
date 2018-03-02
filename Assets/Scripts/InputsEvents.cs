using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InputsEvents : MonoBehaviour {
    public int nature;
    public int trigger_nb;
    public float delay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[CustomEditor(typeof(InputsEvents))]
public class InputsEditorEvents : Editor
{

    public override void OnInspectorGUI()
    {
        InputsEvents mp = (InputsEvents)target;        
        mp.nature = EditorGUILayout.DropdownButton(ButtonController("A"), FocusType.Keyboard);
        /*mp.nature = EditorGUILayout.IntSlider("Bouton", mp.nature, 0, 8);*/
        ProgressBar(mp.nature / 8.0f, "Bouton");       
    }

    void ButtonController(string label)
    {
        GUI.Button(new Rect(0, 30, 100, 20), new GUIContent(label));
    }

    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}
