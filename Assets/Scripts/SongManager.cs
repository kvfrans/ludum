﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] MS = new AudioSource[5];
    public bool startPlaying;
    public BeatScroller bs;
    public float songTimer=-1;
    public int currentSong;
    public int oldSong;
    
    void Start()
    {
        MS = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.Log(songTimer);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            currentSong =0;
            startPlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentSong =1;
            startPlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            currentSong =2;
            startPlaying = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            currentSong =3;
            startPlaying = true;
        }
        if(startPlaying)
        {
            songTimer -= Time.deltaTime;
            if (songTimer <=0){
                //loop song
                startSong(currentSong);
            }
            if(oldSong!=currentSong){
                //swithc songs
                oldSong=currentSong;
                StartCoroutine(newSong(currentSong));

            }

        }
    }

    void startSong(int num){
        StopAllAudio();
        startPlaying = true;
        MS[num].Play();
        bs.startSong(num);
        songTimer = MS[num].clip.length;
    }
    IEnumerator newSong(int num){
        StopAllAudio();
        if(startPlaying){
            MS[4].Play();
        }
        yield return new WaitForSeconds(0.5f);
        startPlaying = true;
        MS[num].Play();
        bs.newSong(num);
        songTimer = MS[num].clip.length;
        Debug.Log(MS[num].clip.length);
    }
    void StopAllAudio() {
     foreach(var audioS in MS) {
         audioS.Stop();
     }
 }
}
