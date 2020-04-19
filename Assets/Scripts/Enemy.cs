using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour {

    // settings
    public bool isBoss = false;
    public bool destroyOnDeath = true;
    public float totalhealth;
    public Transform onDeath;
    private float noDamageTimer = 0;
    public bool takeDamage = true;
    public bool flashOnHit = true;
    public Transform redirectDamageTarget;
    public bool redirectDamage = false;
    
    public List<SpriteRenderer> sprites;
    public float health;
    private Timer flashDur;
    
    // Start is called before the first frame update
    void Start() {
        health = totalhealth;
        flashDur = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashDur.wasJustDone) {
            foreach (var spr in sprites) {
                spr.material.SetFloat("_FlashAmount", 0);
            }
        }
        if (noDamageTimer > 0) {
            noDamageTimer -= Time.deltaTime;
        }
    }

    public void SetNoDamage(float time) {
        noDamageTimer = Mathf.Max(noDamageTimer, time);
    }
    
    public void ResetNoDamage() {
        noDamageTimer = 0;
    }

    public void Damage(float dmg) {
        Damage(dmg, false);
    }
    
    public void Damage(float dmg, bool force) {
        if (noDamageTimer <= 0 && (takeDamage||force)) {
            if (redirectDamage) {
                redirectDamageTarget.GetComponent<Enemy>().Damage(dmg, true);
            }
            health -= dmg;
            if (flashOnHit) {
                foreach (var spr in sprites) {
                    spr.material.SetFloat("_FlashAmount", 1);
                }
                flashDur.time = 0.05f;
            }

            if (health <= 0 && destroyOnDeath) {
                SendMessage(("Death"), SendMessageOptions.DontRequireReceiver);
                DestroyEnemy();
            }
        }
    }
    

    public void DestroyEnemy() {
        GameFlow.Instance.cameras.DOKill();
        GameFlow.Instance.cameras.localEulerAngles = new Vector3(0,0,0);
        GameFlow.Instance.cameras.DOPunchRotation(new Vector3(0, 0, Custom.RandUni()*8), 0.2f);
        GameFlow.Instance.cameras.DOPunchPosition(Custom.RandomInUnitCircle()*0.5f, 0.2f);
        Instantiate(onDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
