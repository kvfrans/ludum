using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
   public float tempo;
    public bool started;
    public GameObject beat;
    private float timer;
    private float spawnInterval;
    private float scrollSpeed;
    public float distanceToClicker;
    void Start()
    {
        tempo = tempo/60f; //beats per s
        timer = 0; 
        scrollSpeed = tempo;
        spawnInterval = 1/tempo;//second per beat
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            // if (Input.anyKeyDown)
            // {
            //     started = true;
            // }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer<0)
            {
                GameObject note =Instantiate(beat, transform);
                note.GetComponent<NoteController>().speed = new Vector3(-scrollSpeed,0f,0f);
                timer = spawnInterval; 
            }
        }
    }
}
