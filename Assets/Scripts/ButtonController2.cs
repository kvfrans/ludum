using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController2 : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer SR;
    public Color unclickImg;
    public Color hitImg;
    public Color missImg;
    public KeyCode keyToHit;
    private bool isNote;
    private int missedNote=-1;
    public GameObject sc;
    private ScoreCounter scoreCounter;
    private AudioSource audioSource;
    public GameObject firstNote;
    public GameObject secondNote;
    
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        scoreCounter = sc.GetComponent<ScoreCounter>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,90*Time.deltaTime); 
        if (missedNote>0){
            if (missedNote ==15){
                scoreCounter.breakCombo();
            }
            SR.color = missImg;
            missedNote -=1;
        }
        if (missedNote==0){
            SR.color = unclickImg;
            missedNote -=1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            if (isNote){
                SR.color = hitImg;
                scoreCounter.hit();
                firstNote.GetComponent<NoteController>().removeNote();
                if (secondNote!=null){
                    firstNote = secondNote;
                }
                else{
                firstNote=null; 
                } 
                
                    
                
            }
            else{
                scoreCounter.breakCombo();
                SR.color = missImg;
                //clicked on nothing
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            SR.color = unclickImg;
        }
    }


    // public void onNoteHit()
    // {
    //     SR.sprite = hitImg;
    // }
    public void onNoteMiss()
    {
        missedNote = 15;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag== "note"){
            isNote = true;
            if (firstNote!=null){
                secondNote = other.gameObject;
                
            }
            else{
                firstNote = other.gameObject;
            }
        }
    }   
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag== "note"){
            if (firstNote==null){
                isNote = false;
            }
        }
    }
}
