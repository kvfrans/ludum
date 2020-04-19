using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float time;
    public bool wasJustDone = false;

    // Update is called once per frame
    void Update() {
        wasJustDone = false;
        if (time > 0) {
            time -= Time.deltaTime;
            if (time <= 0) {
                wasJustDone = true;
            }
        }

    }
}