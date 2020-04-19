using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
    public float fadeTime = 0.1f;
    public float startTime = 10;
    private float time = 0;
    public bool destroyAfter = true;

    private float alphaStart = 0;

    private Vector2 target;

    // Update is called once per frame
    void Awake() {
        alphaStart = GetComponent<SpriteRenderer>().color.a;
        target = transform.localScale;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        if (time > startTime) {
            Color c = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alphaStart*(1 - (time-startTime)/fadeTime));
            if (time >= startTime+fadeTime) {
                GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 0);
                if (destroyAfter) {
                    Destroy(transform.gameObject);
                }
            }
        }
    }

    public void Fade() {
        time = startTime;
    }
}
