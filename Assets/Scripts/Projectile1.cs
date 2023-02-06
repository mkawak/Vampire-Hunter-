using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : Projectile
{
    void Start() {
        speed = 25;
        lifeTime = 5;
        hits = 1;
    }

    new void Update() {
        Move();
        base.Update();
    }
}
