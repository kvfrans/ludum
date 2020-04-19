using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleIn : MonoBehaviour {
    public float scaleTime = 0.1f;
    private float time = 0;
    public Vector2 initialScale = new Vector2(0, 0);

    private Vector2 target;

    // Update is called once per frame
    void Awake() {
        target = transform.localScale;
        transform.localScale = new Vector3(0,0,1);
    }

    public void SetTarget(Vector2 scale) {
        target = scale;
    }
    
    public Vector2 GetTarget() {
        return target;
    }
    void Update()
    {
        if (time < scaleTime) {
            transform.localScale = new Vector3(time / scaleTime * target.x, time / scaleTime * target.y, 1) +
                                   (Vector3)initialScale * (1 - time / scaleTime);
            time += Time.deltaTime;
            if (time >= scaleTime) {
                transform.localScale = new Vector3(target.x,target.y,1);
                Destroy(this);
            }
        }
    }
}
