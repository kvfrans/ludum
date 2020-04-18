using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource MS;
    public bool startPlaying;
    public BeatScroller bs;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                bs.started = true;
                MS.Play();
            }
        }
    }
}
