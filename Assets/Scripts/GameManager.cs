using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    Player player;
    private Vector3 playerPos;
    public ControllerManager controllerManager;
    public float globalTimer;
    private float timer;    
    public EventManager[] eventList;
    private EventManager ev;
    
    void Start () {   
        timer = Time.deltaTime;
        player = (Player)FindObjectOfType(typeof(Player));        
    }	

	void Update () {
        playerPos = player.transform.position;
       
        timer += Time.deltaTime;
        Debug.Log(timer);

        if (timer >= globalTimer)
        {
            Debug.Log("End of the game");
        }   
        
        for(int i = 0; i < eventList.Length; i++)
        {            
            if (timer >= eventList[i].minuteur)
            {                
                if (eventList[i].triggered == false)
                {                    
                    eventList[i].triggered = true;

                    if (!eventList[i].GetComponent<EventSkybox>())
                    {
                        eventList[i].gameObject.SetActive(true);
                        eventList[i].transform.position = eventList[i].RotateAround(eventList[i].distance);
                    }
                    else
                    {
                        eventList[i].gameObject.SetActive(true);
                    }
                }
                else
                {
                    //do nothing
                }
            }
        }
    }

    void OnApplicationQuit()
    {
        controllerManager.setVibration(0, 0);
    }
}
