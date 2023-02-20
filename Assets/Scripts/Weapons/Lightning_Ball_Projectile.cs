using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning_Ball_Projectile : Projectile
{
    float offset = 0;


    void Start() {
        speed = 8;
        lifeTime = 6.1f;
        hits = 99;
    }

    bool grow = false;
    float timeSinceFlip = 0f;
    new void Move(float deltaTime) {
        base.Move();

        float currGrow = (deltaTime + Random.Range(0, 0.0001f)) * ((grow) ? 1 : -1);
        transform.localScale = new Vector3(transform.localScale.x + currGrow / 3f, transform.localScale.y + currGrow / 3f, transform.localScale.z);
        timeSinceFlip += deltaTime;
        if(timeSinceFlip > 0.7f) {
            grow = !grow;
            timeSinceFlip = 0;
        }
    }

    new void Update() {
        Move(Time.deltaTime);
        base.Update();
    }
}
