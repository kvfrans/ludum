using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GoonCharge : MonoBehaviour {
    
    private Rigidbody2D rb;

    public Transform body;
    private float speedbase = 0;
    private Vector3 delta;
    private Vector3 adj;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speedbase = Random.value*0.5f;
        adj = Custom.RandomInUnitCircle() * 10;
    }

    // Update is called once per frame
    void Update() {
        speedbase += Time.deltaTime;
        if (speedbase > 0.5f) {
            StartCoroutine(Move());
            speedbase = 0;
        }
    }

    IEnumerator Move() {
        Vector3 target = GameFlow.Instance.player.position + adj;
        delta = target - transform.position;
        delta.z = 0;
        delta = delta.normalized;
        rb.velocity = delta * 3;
        
        float bodyAng = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 90;
        body.DORotate(new Vector3(0, 0, bodyAng + Custom.RandUni()*20), 0.25f);
        
        yield return new WaitForSeconds(0.25f);
        rb.velocity = Vector2.zero;
    }
}