using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
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
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        scoreCounter = sc.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,90*Time.deltaTime); 
        if (missedNote>0){
            if (missedNote ==15){
                scoreCounter.breakCombo();
            }
            SR.sprite = missImg;
            missedNote -=1;
        }
        if (missedNote==0){
            SR.color = unclickImg;
            missedNote -=1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (isNote){
                SR.sprite = hitImg;
                scoreCounter.hit();
            }
            else{
                scoreCounter.breakCombo();
                SR.sprite = missImg;
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
        }
    }   
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag== "note"){
            isNote = false;
        }
    }
}
