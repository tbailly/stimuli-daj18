using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EventManager : MonoBehaviour
{
    private CharacterController player;
    public float minuteur;
    public float distance;

    private void Start()
    {
        player = (CharacterController)FindObjectOfType(typeof(CharacterController));
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    public void Activate()
    {
        if (GetComponent<EventSound>())
            GetComponent<EventSound>().StartEventSound();
    }
}
public enum Rotation{ None, degrees0, degrees45, degrees90, degrees135, degrees180, degrees225, degrees270, degrees315};
public enum TypeEvent { None, Son, Skybox, Interaction };

[CustomEditor(typeof(EventManager))]

public class EventEditor : Editor
    {
    EventManager e;
    Vector3 pos = new Vector3 (0,0,0);
    public Rotation rotation;
    public TypeEvent type;
    private TypeEvent prev;

    private void Awake()
    {
       e = (EventManager)target;       
    }

    public override void OnInspectorGUI()
    {
        prev = type;
        e.minuteur = EditorGUILayout.FloatField("Minuteur :", e.minuteur);
        e.distance = EditorGUILayout.FloatField("Distance :", e.distance);
        rotation = (Rotation)EditorGUILayout.EnumPopup("Rotation :", rotation);
        type = (TypeEvent)EditorGUILayout.EnumPopup("Type d'événement :", type);

       if (GUILayout.Button("Create"))
            ComponentSettings(rotation, type);

    }

    void ComponentSettings(Rotation _rotation, TypeEvent _type)
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

        switch (type)
           {
               case TypeEvent.Son:
                if (e.gameObject.GetComponent<EventSound>() == null)
                {
                    e.gameObject.AddComponent<EventSound>();
                    e.gameObject.AddComponent<AudioSource>();
                    e.gameObject.GetComponent<AudioSource>().playOnAwake = false;
                    e.gameObject.GetComponent<AudioSource>().spatialBlend = 1;
                }
                break;

                case TypeEvent.Skybox:
                if (e.gameObject.GetComponent<SkyboxEventManager>() == null)
                    e.gameObject.AddComponent<SkyboxEventManager>();              
                   break;

                case TypeEvent.Interaction:
                if (e.gameObject.GetComponent<InteractionManager>() == null)
                    e.gameObject.AddComponent<InteractionManager>();
                break;
           }
       

        
    }
}
