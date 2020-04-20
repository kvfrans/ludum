using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform cameras;
    private Rigidbody2D rb;
    public Transform spriteBody;
    public Transform gun;

    public Transform bullet;
    public Transform bulletOnShoot;
    
    private float bodyrot;
    private float camerarot;
    private Vector2 dashVelocity;

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
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(horiz) < 0.1f) {
            horiz = 0;
        }
        if (Mathf.Abs(vert) < 0.1f) {
            vert = 0;
        }
        rb.velocity = Rotate(new Vector2(horiz, vert), camerarot*Mathf.Deg2Rad) * 5;
        if (rb.velocity.magnitude > 0) {
            bodyrot += Time.deltaTime * 10;
        }
        
        rb.velocity += dashVelocity;
        dashVelocity *= (1 - Time.deltaTime*10);


        Vector3 mousePosition = Input.mousePosition;
        float ang = Mathf.Atan2( mousePosition.y - Screen.height/2.0f,  mousePosition.x - Screen.width/2.0f) * Mathf.Rad2Deg;

        float bodyAng = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 90;
        spriteBody.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(spriteBody.localEulerAngles.z, bodyAng + Mathf.Sin(bodyrot)*30, Time.deltaTime*10));
        camerarot = Mathf.Atan2(transform.position.y - 200, transform.position.x*2) * Mathf.Rad2Deg + 90;
        transform.localEulerAngles = new Vector3(0, 0, camerarot);
        if (gun != null) {
            gun.localEulerAngles = new Vector3(0, 0, ang);
        }

        if (Input.GetMouseButtonDown(0)) {
            Transform bo = Instantiate(bulletOnShoot, transform.position + Custom.Vector3FromDir(ang)*0.3f + new Vector3(0,0,-2), Quaternion.identity);
//            bo.GetComponent<Rigidbody2D>().velocity += rb.velocity * 0.8f;

            for (int i = 0; i < 6; i++) {
                Transform b = Instantiate(bullet, transform.position + new Vector3(0,0,-2), Quaternion.identity);
                b.GetComponent<Rigidbody2D>().velocity = Custom.VectorFromDir(ang + Custom.RandUni()*10 + camerarot) * (10 + Random.value * 5);
//                b.GetComponent<Rigidbody2D>().velocity += rb.velocity * 0.8f;
            }

            cameras.DOKill();
            cameras.localPosition = new Vector3(0,0,0);
            cameras.localEulerAngles = new Vector3(0,0,0);
            cameras.DOPunchRotation(new Vector3(0, 0, Custom.RandUni()*5), 0.2f);
            cameras.DOPunchPosition(Custom.RandomInUnitCircle()*0.2f, 0.2f);
        }

        if (Input.GetMouseButtonDown(1)) {
            dashVelocity = Custom.VectorFromDir(ang) * 50;
        }
    }
    
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
