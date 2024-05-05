using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    PlayableDirector director;
    GameObject cutscene;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponentInChildren<PlayableDirector>();
        cutscene = GameObject.Find("Opening Cutscene");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(director.state != PlayState.Playing)
        {
            director.Stop();
            cutscene.SetActive(false);
            
        }
    }
}
