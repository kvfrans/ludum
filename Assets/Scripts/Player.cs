using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private Rigidbody2D rb;
    public Transform spriteBody;
    
    private float bodyrot;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if (Mathf.Abs(horiz) < 0.1f) {
            horiz = 0;
        }
        if (Mathf.Abs(vert) < 0.1f) {
            vert = 0;
        }
        rb.velocity = new Vector2(horiz, vert) * 5;

        Vector3 mousePosition = Input.mousePosition;
        float ang = Mathf.Atan2( mousePosition.y - Screen.height/2.0f,  mousePosition.x - Screen.width/2.0f) * Mathf.Rad2Deg + 90;
        
        if (rb.velocity.magnitude > 0) {
            bodyrot += Time.deltaTime * 10;
        }
        spriteBody.localEulerAngles = new Vector3(0, 0, ang + Mathf.Sin(bodyrot)*30);
    }
    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
