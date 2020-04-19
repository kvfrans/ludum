using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon : MonoBehaviour {
    
    private Rigidbody2D rb;

    public Transform body;
    private float bodyrot;
    private float speedbase = 0;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speedbase = Random.value*360;
    }

    // Update is called once per frame
    void Update() {
        Vector3 delta = GameFlow.Instance.player.position - transform.position;
        delta.z = 0;
        delta = delta.normalized;
        speedbase += Time.deltaTime * 50;
        rb.velocity = delta * Mathf.Max(0, 0.5f + Mathf.Sin(speedbase*Mathf.Deg2Rad)*4);
        
        if (rb.velocity.magnitude > 0) {
            bodyrot += Time.deltaTime * 10;
        }

        float bodyAng = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 90;
        body.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(body.localEulerAngles.z, bodyAng + Mathf.Sin(bodyrot)*30, Time.deltaTime*10));
    }
}
