using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Event : MonoBehaviour
{
    private CharacterController player;
    public float minuteur;
    public float distance;

    private void Start()
    {
        player = (CharacterController)FindObjectOfType(typeof(CharacterController));
        gameObject.transform.position = new Vector3(0, 0, 0);
    }   
}
public enum Rotation{ None, degrees0, degrees45, degrees90, degrees135, degrees180, degrees225, degrees270, degrees315};
public enum Type { None, Son, Lumière, Interaction };

[CustomEditor(typeof(Event))]

public class EventEditor : Editor
    {
    Event e;
    Vector3 pos = new Vector3 (0,0,0);
    public Rotation rotation;
    public Type type;
    private Type prev;

    private void Awake()
    {
       e = (Event)target;       
    }

    public override void OnInspectorGUI()
    {
        prev = type;
        e.minuteur = EditorGUILayout.FloatField("Minuteur :", e.minuteur);
        e.distance = EditorGUILayout.FloatField("Distance :", e.distance);
        rotation = (Rotation)EditorGUILayout.EnumPopup("Rotation :", rotation);
        type = (Type)EditorGUILayout.EnumPopup("Type d'événement :", type);

       if (GUILayout.Button("Create"))
            ComponentSettings(rotation, type);

    }

    void ComponentSettings(Rotation _rotation, Type _type)
    {
        //ROTATION
        switch (rotation)
        {
            case Rotation.degrees0:
                e.gameObject.transform.position = new Vector3(pos.x + e.distance, pos.y, pos.z);
                break;
            case Rotation.degrees45:
                e.gameObject.transform.position = new Vector3(pos.x + e.distance, pos.y, pos.z + e.distance);
                break;
            case Rotation.degrees90:
                e.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + e.distance);
                break;
            case Rotation.degrees135:
                e.gameObject.transform.position = new Vector3(pos.x - e.distance, pos.y, pos.z + e.distance);
                break;
            case Rotation.degrees180:
                e.gameObject.transform.position = new Vector3(pos.x - e.distance, pos.y, pos.z);
                break;
            case Rotation.degrees225:
                e.gameObject.transform.position = new Vector3(pos.x - e.distance, pos.y, pos.z - e.distance);
                break;
            case Rotation.degrees270:
                e.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z - e.distance);
                break;
            case Rotation.degrees315:
                e.gameObject.transform.position = new Vector3(pos.x + e.distance, pos.y, pos.z - e.distance);
                break;
            default:
                e.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
                break;
        }

        //ADD/DELETE COMPONENT BY EVENT TYPE
        if (e.gameObject.GetComponent<SoundManager>())
        {
            DestroyImmediate(e.gameObject.GetComponent<SoundManager>());
        }
        else if (e.gameObject.GetComponent<LightManager>())
        {
            DestroyImmediate(e.gameObject.GetComponent<LightManager>());
        }
        else if (e.gameObject.GetComponent<InteractionManager>())
        {
            DestroyImmediate(e.gameObject.GetComponent<InteractionManager>());
        }

        switch (type)
           {
               case Type.Son:
                if (e.gameObject.GetComponent<SoundManager>() == null)                
                    e.gameObject.AddComponent<SoundManager>();   
                   break;

                case Type.Lumière:
                if (e.gameObject.GetComponent<LightManager>() == null)
                    e.gameObject.AddComponent<LightManager>();              
                   break;

                case Type.Interaction:
                if (e.gameObject.GetComponent<InteractionManager>() == null)
                    e.gameObject.AddComponent<InteractionManager>();
                break;
           }
       

        
    }
}
