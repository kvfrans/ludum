﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour {
    
    public float damage;
    public bool isPlayer = true;
    public bool collideWithSolid = true;
    public bool destroyOnHit = true;

    public Transform onHit;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
//            Enemy e = other.gameObject.GetComponent<Enemy>();
//            e.Damage(damage);
//            if (destroyOnHit) {
//                DestroyBullet();
//            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Walls") && collideWithSolid) {
            DestroyBullet();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
//            PlayerHitbox ph = other.GetComponent<PlayerHitbox>();
//            if (ph != null) {
//                other.transform.parent.GetComponent<Player>().TakeDamage();
//            }
        }
    }
    
    public void DestroyBullet() {
        if (onHit != null) {
            Instantiate(onHit, transform.position + new Vector3(0, 0, -0.3f), Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
