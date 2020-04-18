using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private Rigidbody2D rb;
    public Transform spriteBody;
    
    private float bodyrot;
    private float camerarot;
    

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public static Vector2 Rotate(Vector2 v, float delta) {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
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
        rb.velocity = Rotate(new Vector2(horiz, vert), camerarot*Mathf.Deg2Rad) * 5;


        Vector3 mousePosition = Input.mousePosition;
        float ang = Mathf.Atan2( mousePosition.y - Screen.height/2.0f,  mousePosition.x - Screen.width/2.0f) * Mathf.Rad2Deg + 90;
        
        if (rb.velocity.magnitude > 0) {
            bodyrot += Time.deltaTime * 10;
        }
        spriteBody.localEulerAngles = new Vector3(0, 0, ang + Mathf.Sin(bodyrot)*30);
        camerarot = Mathf.Atan2(transform.position.y - 200, transform.position.x) * Mathf.Rad2Deg + 90;
        transform.localEulerAngles = new Vector3(0, 0, camerarot);
    }
    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
