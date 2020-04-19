using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOut : MonoBehaviour {
    public float scaleTime = 0.1f;
    public float scaleStartTime = 10;
    private float time = 0;
    public bool destroy = true;
    public Vector2 finalScale = new Vector2(0, 0);

    private Vector2 target;
    private bool targetSet = false;

    // Update is called once per frame
    void Awake() {
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > scaleStartTime) {
            if (!targetSet) {
                targetSet = true;
                target = new Vector2(transform.localScale.x, transform.localScale.y);
//                Debug.Log(target);
            }
            transform.localScale = new Vector3((1-((time-scaleStartTime)/scaleTime)) * target.x,(1-((time-scaleStartTime)/scaleTime)) * target.y,1) + (Vector3)finalScale*((time-scaleStartTime)/scaleTime);
            if (time >= scaleTime+scaleStartTime) {
                transform.localScale = new Vector3(finalScale.x, finalScale.y,1);
                if (destroy) {
                    Destroy(gameObject);
                }
                else {
                    Destroy(this);
                }
            }
        }
    }

    public void Scale() {
        time = scaleStartTime;
    }
}
