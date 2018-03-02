using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InputsEvents))]

public class InputsEventsEditor : Editor {

    SerializedProperty nature;
    SerializedProperty trigger_nb;
    SerializedProperty delay;

    void OnEnable()
    {
        nature = serializedObject.FindProperty("nature");
        trigger_nb = serializedObject.FindProperty("trigger_nb");
        delay = serializedObject.FindProperty("delay");

    }

}
