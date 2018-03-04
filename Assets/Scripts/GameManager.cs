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
    public Hub hub;
    public bool isInterior = false;
    private bool oldInterior = false;
    private EventManager ev;
    
    void Start () {   
        timer = Time.deltaTime;
        player = (Player)FindObjectOfType(typeof(Player));
        StartCoroutine("SpawnHub");  
    }	

	void Update () {
        playerPos = player.transform.position;

        if (oldInterior != isInterior)
            timer = 0;
        timer += Time.deltaTime;
        if (timer >= globalTimer && isInterior == true)
        {
            //Debug.Log("End of the game");
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
                        Instantiate(eventList[i]);
                    }
                }
                else
                {
                    //do nothing
                }
            }
        }
        oldInterior = isInterior;
    }

    IEnumerator SpawnHub()
    {
        yield return new WaitForSeconds(90);
        hub.gameObject.SetActive(true);
        hub.transform.position = hub.RotateAround(0);
    }

    void OnApplicationQuit()
    {
        controllerManager.setVibration(0, 0);
    }
}
