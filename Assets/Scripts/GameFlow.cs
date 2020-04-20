using System;
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

    public Transform player;
    public Transform cameras;
    public Transform ppv;
    private Volume v;
    ColorAdjustments ca;
    public SongManager sm;
    public ScoreCounter sc;

    public Transform goon;
    public Transform goon2;
    public Transform song;
    private float goonSpawner = 0;
    private float goonSpawner2 = 0;
    private float songSpawner = 0;

    public float hueShift = 0;
    
    // Start is called before the first frame update
    void Start() {
        hueShift = 180;
        v = ppv.GetComponent<Volume>();
        v.profile.TryGet(out ca);
    }

    // Update is called once per frame
    void Update() {
        hueShift += Time.deltaTime*0.5f;
//        ca.hueShift.value = Mathf.Sin(hueShift) * 20;

        goonSpawner -= Time.deltaTime;
        goonSpawner2 -= Time.deltaTime;
        songSpawner -= Time.deltaTime;
        if (goonSpawner < 0) {
            goonSpawner = 0.8f;
            Transform g = Instantiate(goon, new Vector3(4, 4, -0.1f) + Custom.RandomInUnitCircle() * 20, Quaternion.identity);
        }
        if (goonSpawner2 < 0) {
            goonSpawner2 = 4;
            Transform g = Instantiate(goon2, new Vector3(4, 4, -0.1f) + Custom.RandomInUnitCircle() * 20, Quaternion.identity);
        }
        if (songSpawner < 0) {
            songSpawner = 4;
            Transform g = Instantiate(song, new Vector3(4, 4, -0.1f) + Custom.RandomInUnitCircle() * 20, Quaternion.identity);
        }

    }

    private void OnDisable() {
        ca.hueShift.value = 0;
    }
}
