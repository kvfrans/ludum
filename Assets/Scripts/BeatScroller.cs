using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeatScroller : MonoBehaviour
{
    public bool started;
    public GameObject beat;
    private float timer;
    public float distanceToClicker;
    public int currBeatIndex;
    public int currSongIndex;
    public List<float> currMap = new List<float>();
    private List<GameObject> spawnList = new List<GameObject>();
    public Hashtable[] songList = new Hashtable[3];
    private Hashtable song1 = new Hashtable();
    public List<float> map1 = new List<float>();
    private Hashtable song2 = new Hashtable();
    public List<float> map2 = new List<float>();
    private Hashtable song3 = new Hashtable();
    public List<float> map3 = new List<float>();

    void Start()
    {
        //song1 stats
        song1.Add("Length",21.46f);
        song1.Add("Tempo",90f/60f);//beats per s
        song1.Add("scrollSpeed",distanceToClicker/(2.5f/(float)song1["Tempo"]));//whole bar is 2 beat
        float num = 0.2f; //offset
        while (num < (float)song1["Length"]){
            map1.Add(num);
            num+=1/(float)song1["Tempo"];
        }
        song1.Add("beatMap",map1);
        songList[0] = song1;

        //song2stats
        song2.Add("Length",14.45f);
        song2.Add("Tempo",100f/60f);//beats per s
        song2.Add("scrollSpeed",distanceToClicker/(2f/(float)song2["Tempo"]));//whole bar is 2 beat
        num = 1.3f; //offset
        int iter = 0;
        while (num < (float)song2["Length"]){
            map2.Add(num);
            if (iter%3==0){
                num+=3f/20f*10f;
            }
            else if (iter%3==1){
                num+=3f/20f*3f;
            }
            else if (iter%3==2){
                num+=3f/20f*3f;
            }
            iter+=1;
        }
        song2.Add("beatMap",map2);
        songList[1] = song2;

        //song2stats
        song3.Add("Length",19.32f);
        song3.Add("Tempo",100f/60f);//beats per s
        song3.Add("scrollSpeed",distanceToClicker/(2f/(float)song3["Tempo"]));//whole bar is 2 beat
        num = 1.4f; //offset
        iter = 0;
        while (num < (float)song3["Length"]){
            map3.Add(num);
            if (iter%6==0){
                num+=3f/20f*4f;
            }
            else if (iter%6==1){
                num+=3f/20f*3f;
            }
            else if (iter%6==2){
                num+=3f/20f*1f;
            }
            else if (iter%6==3){
                num+=3f/20f*4f;
            }
            else if (iter%6==4){
                num+=3f/20f*2f;
            }
            else if (iter%6==5){
                num+=3f/20f*2f;
            }
            iter+=1;
        }
        song3.Add("beatMap",map3);
        songList[2] = song3;
    }

    // Update is called once per frame
    void Update()
    {
        if(started)
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= currMap[currBeatIndex]){
                spawnNote(currSongIndex);
                currBeatIndex+=1;
            }
        }
    }
    public void startSong(int num){
        started= true;
        timer = 0;
        currMap =  (System.Collections.Generic.List<float>)songList[num]["beatMap"];
        currBeatIndex = 0;
        currSongIndex = num;
    }
    public void newSong(int num){
        started= true;
        timer = 0;
        currMap =  (System.Collections.Generic.List<float>)songList[num]["beatMap"];
        currBeatIndex = 0;
        currSongIndex = num;
        //clear notes
        foreach (GameObject note in spawnList){
            Destroy(note);
        }
        spawnList.Clear();
    }

    void spawnNote(int num){
        GameObject note =Instantiate(beat, transform);
        note.GetComponent<NoteController>().speed = new Vector3(-(float)songList[num]["scrollSpeed"],-(float)songList[num]["scrollSpeed"],0f);
        note.transform.position = transform.position;
        spawnList.Add(note);


    }
}
