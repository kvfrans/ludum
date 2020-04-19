using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] MS;
    public bool startPlaying;
    public BeatScroller bs;
    public float songTimer=0;
    public float timer=0;
    public int currentSong;
    public int oldSong;
    
    void Start()
    {
        MS = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(startPlaying)
        {
            songTimer -= Time.deltaTime;
            Debug.Log(songTimer);
            if (songTimer <=0){
                //loop song
                StartCoroutine(startSong(currentSong,0f));

            }
            if(oldSong!=currentSong){
                //swithc songs
                oldSong=currentSong;
                StartCoroutine(startSong(currentSong,1f));

            }

        }
    }

    IEnumerator startSong(int num,float wait){
        StopAllAudio();
        // if(startPlaying){
        //     MS[2].Play();
        // }
        yield return new WaitForSeconds(wait);
        //reset timer her and beastscroller
        startPlaying = true;
        bs.startSong(num);
        MS[num].Play();
        songTimer = MS[num].clip.length;
    }
    void StopAllAudio() {
     foreach(var audioS in MS) {
         audioS.Stop();
     }
 }
}
