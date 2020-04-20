using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public Vector3 scale;
    public Vector3 speed;
    public string zone;
    public KeyCode pressKey;
    public ButtonController2 buttonController;
    // Start is called before the first frame update
    void Start()
    {
        zone = "None";
        transform.localScale = new Vector3(5f,5f,1f);
        GameObject clicker = GameObject.Find("Clicker");
        buttonController = clicker.GetComponent<ButtonController2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale + speed * Time.unscaledDeltaTime;
        if (zone =="Perfect"){
            if (Input.GetMouseButtonDown(0)){
                // buttonController.onNoteHit();
                Destroy(gameObject);
                Debug.Log("hit");
            }
        }
        // if (zone =="Good"){
        //     if (Input.GetMouseButtonDown(0)){
        //         Destroy(gameObject);
        //     }
        // }
        if (transform.localScale[0]<0){
            buttonController.onNoteMiss();
            Destroy(gameObject);
            
            //miss
        }


    }
    private void OnTriggerEnter2D(Collider2D other) {
        // if (other.tag== "Perfect"){
        //     zone = "Perfect";
        // }
        zone = other.tag;
    }
    private void OnTriggerExit2D(Collider2D other) {
        // if (other.tag== "Perfect"){
        //     zone = "None";
        // }
        zone = "none";
    }
}

