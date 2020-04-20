using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pickup : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            float rand = Random.value;
            if (rand < 0.25f) {
                GameFlow.Instance.sm.currentSong = 1;
            }
            else if (rand < 0.5f) {
                GameFlow.Instance.sm.currentSong = 2;
            }
            else if (rand < 0.75f) {
                GameFlow.Instance.sm.currentSong = 3;
            }
            else {
                GameFlow.Instance.sm.currentSong = 4;
            }
            GameFlow.Instance.sm.startPlaying = true;
            Destroy(gameObject);
        }
    }
    
}
