using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    public static float RandUni() {
        return (Random.value - 0.5f) * 2;
    }

    public static Vector3 RandomInUnitCircle() {
        return Random.insideUnitCircle;
    }

    public static Vector2 VectorFromDir(float dir) {
        return new Vector2(Mathf.Cos(dir*Mathf.Deg2Rad), Mathf.Sin(dir*Mathf.Deg2Rad));
    }
    
    public static Vector3 Vector3FromDir(float dir) {
        return new Vector3(Mathf.Cos(dir*Mathf.Deg2Rad), Mathf.Sin(dir*Mathf.Deg2Rad), 0);
    }
    
    
}
