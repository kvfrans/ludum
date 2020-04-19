﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class GameFlow : MonoBehaviour {
    
    protected static GameFlow instance;
    public static GameFlow Instance {
        get {
            if (instance != null)
                return instance;
            instance = FindObjectOfType<GameFlow>();
            return instance;
        }
    }

    public Transform ppv;
    private Volume v;
    ColorAdjustments ca;

    public float hueShift = 0;
    // Start is called before the first frame update
    void Start() {
        hueShift = 180;
        v = ppv.GetComponent<Volume>();
        v.profile.TryGet(out ca);
    }

    // Update is called once per frame
    void Update() {
        hueShift += Time.deltaTime*2;
        if (hueShift > 360) {
            hueShift -= 360;
        }
        ca.hueShift.value = hueShift - 180;
    }

    private void OnDisable() {
        ca.hueShift.value = 0;
    }
}