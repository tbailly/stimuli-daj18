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
                    Instantiate(eventList[i], eventList[i].RotateAround(eventList[i].distance), Quaternion.identity);                  
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
