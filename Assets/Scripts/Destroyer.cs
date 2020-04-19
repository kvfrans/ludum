using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
    public float destroyAfter = 0;
    
    public void DestroyMe() {
        Destroy(gameObject);
    }

    void Start() {
        if (destroyAfter != 0) {
            StartCoroutine(DestroySoon());
        }
    }

    IEnumerator DestroySoon() {
        yield return new WaitForSeconds(destroyAfter);
        Destroy(gameObject);
    }
}
