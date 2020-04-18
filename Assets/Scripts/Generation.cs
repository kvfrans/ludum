using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {

    public Transform wall;
    public Transform floor;

    // Update is called once per frame
    void Start() {
        for (int x = 0; x < 20; x++) {
            for (int y = 0; y < 20; y++) {
                Transform atTile = null;
                if ((x == 0 || x == 19 || y == 0 || y == 19) && x % 3 == 0) {
                    atTile = wall;
                    Transform t = Instantiate(atTile, new Vector3(x*2, y*2, 0), Quaternion.identity);
                }
                else {
                    atTile = floor;
                }

            }
        }
    }
}
