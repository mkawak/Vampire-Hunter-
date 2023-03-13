using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty_Explosion : Projectile
{
    void Start() {
        speed = 0;
        lifeTime = 0.3f;
        hits = 999;
        AudioManager.Instance.PlaySFX("DiamondExplosionSFX");
    }

    void Move(float deltaTime) {
        // transform.localScale += new Vector3(deltaTime * 100 * ((lifeTime + 0.01f) / 0.3f), deltaTime * 100 * ((lifeTime + 0.01f) / 0.3f), 0);
    }

    new void Update() {
        Move(Time.deltaTime);
        base.Update();
    }
}