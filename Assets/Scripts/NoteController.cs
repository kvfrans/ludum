using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public Vector3 speed;
    public string zone;
    public KeyCode pressKey;
    // Start is called before the first frame update
    void Start()
    {
        zone = "None";
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = transform.localPosition + speed * Time.deltaTime;
        if (zone =="clicker"){
            if (Input.GetKeyDown(pressKey)){
                gameObject.SetActive(false);
            }
        }


    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag== "clicker"){
            zone = "clicker";
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag== "clicker"){
            zone = "None";
        }
    }
}

