using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour {

    public Transform wall;
    public Transform floor;

    private static int size = 100;
    public class Grid<T> {
        private T[] gridData = new T[size * size];

        public T this[int x, int y] {
            get {
                if (x < 0 || x >= size || y < 0 || y >= size) {
                    return (T) Activator.CreateInstance(typeof(T));
                }

                return gridData[x * size + y];
            }
            set {
                if (x < 0 || x >= size || y < 0 || y >= size) {
                }
                else {
                    gridData[x * size + y] = value;
                }
            }
        }

        public void SetGridData(T[] g) {
            gridData = g;
        }

        public T[] GetGridData() {
            return (T[]) gridData.Clone();
        }
    }

    // Update is called once per frame
    void Start() {
        Grid<int> map;
        for (int x = 0; x < 60; x++) {
            for (int y = 0; y < 60; y++) {
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
