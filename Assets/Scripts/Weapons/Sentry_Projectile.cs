using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry_Projectile : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 4f;
        hits = 1;
        speed = 80f;
    }

    // Update is called once per frame
    void Update()
    {
        base.Move();
        base.Update();
    }
}
