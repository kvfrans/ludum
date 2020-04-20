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
    private int missedNote;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,90*Time.deltaTime); 
        if (missedNote>0){
            SR.color = missImg;
            missedNote -=1;
        }
        if (missedNote==0){
            SR.color = unclickImg;
            missedNote -=1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (isNote){
                SR.color = hitImg;
            }
            else{
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
        }
    }   
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag== "note"){
            isNote = false;
        }
    }
}
