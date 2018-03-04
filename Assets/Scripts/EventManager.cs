using System.Collections;
using UnityEditor;
using UnityEngine;

public class EventManager : MonoBehaviour
{    
    public float minuteur;
    public float lifetime;  
    public float distance;
    public enum Rotation { None, degrees0, degrees45, degrees90, degrees135, degrees180, degrees225, degrees270, degrees315 };
    public Rotation rotation;
    public bool triggered;
    private IEnumerator coroutine;

    private void Start()
    {    
        coroutine = ActivateTimer(lifetime);
        StartCoroutine(coroutine);
    }

    public IEnumerator ActivateTimer(float _lifetime)
    {
        while (true)
        {        
            _lifetime -= 1.0f;

            if (_lifetime <= 0)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void Update()
    {        
        
    }
    
    public void Activate()
    {
        if (GetComponent<EventSound>())
            GetComponent<EventSound>().StartEventSound();        
    } 

    //Spawn an object at a random position around a point with a given distance
    public Vector3 RotateAround(float distance)
    {
        float angle = Random.Range(0.0f, Mathf.PI * 2);       
        Vector3 V = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        V *= distance;
        return V;
    }

    //NOT USED
    public Vector3 SetPosition(Rotation rotation)
    {
        Player player = (Player)FindObjectOfType(typeof(Player));
        Vector3 playerPos = player.transform.position;
        Vector3 newPos;

        //ROTATION
        switch (rotation)
        {
            case Rotation.degrees0:
                newPos = new Vector3(playerPos.x + distance, playerPos.y, playerPos.z);
                break;
            case Rotation.degrees45:
                newPos = new Vector3(playerPos.x + distance, playerPos.y, playerPos.z + distance);
                break;
            case Rotation.degrees90:
                newPos = new Vector3(playerPos.x, playerPos.y, playerPos.z + distance);
                break;
            case Rotation.degrees135:
                newPos = new Vector3(playerPos.x - distance, playerPos.y, playerPos.z + distance);
                break;
            case Rotation.degrees180:
                newPos = new Vector3(playerPos.x - distance, playerPos.y, playerPos.z);
                break;
            case Rotation.degrees225:
                newPos = new Vector3(playerPos.x - distance, playerPos.y, playerPos.z - distance);
                break;
            case Rotation.degrees270:
                newPos = new Vector3(playerPos.x, playerPos.y, playerPos.z - distance);
                break;
            case Rotation.degrees315:
                newPos = new Vector3(playerPos.x + distance, playerPos.y, playerPos.z - distance);
                break;
            default:
                newPos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
                break;
        }
        return newPos;
    }
}


/********************************
 * CUSTOM EDITOR
 *********************************/
public enum TypeEvent { None, Son, Graphique, Skybox, Interaction };

[CustomEditor(typeof(EventManager))]
public class EventEditor : Editor
    {
    EventManager e;

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
        e.lifetime = EditorGUILayout.FloatField("Durée de vie :", e.lifetime);
        e.distance = EditorGUILayout.FloatField("Distance :", e.distance);
        //e.rotation = (EventManager.Rotation)EditorGUILayout.EnumPopup("Rotation :", e.rotation);
        e.triggered = EditorGUILayout.Toggle("Triggered ? :", e.triggered);
        type = (TypeEvent)EditorGUILayout.EnumPopup("Type d'événement :", type);

        if (GUI.changed)
        {
            e.minuteur = EditorGUILayout.FloatField("Minuteur :", e.minuteur);
            e.lifetime = EditorGUILayout.FloatField("Durée de vie :", e.lifetime);
            e.distance = EditorGUILayout.FloatField("Distance :", e.distance);
        }
           

        if (GUILayout.Button("Create"))
            ComponentSettings(type);
    }

    //Set parameters by event type
    void ComponentSettings(TypeEvent _type)
    {    
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

                case TypeEvent.Graphique:
                if (e.gameObject.GetComponent<ObjectFadeOnApproach>() == null)
                {
                    e.gameObject.AddComponent<ObjectFadeOnApproach>();                
                }
                break;


            case TypeEvent.Skybox:
                if (e.gameObject.GetComponent<EventSkybox>() == null)
                    e.gameObject.AddComponent<EventSkybox>();              
                   break;

                case TypeEvent.Interaction:
                if (e.gameObject.GetComponent<EventInteraction>() == null)
                    e.gameObject.AddComponent<EventInteraction>();
                break;
           }
     
    }
}
