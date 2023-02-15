using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_BasicAttack_Projectile : Projectile
{
    GameObject player;

    float offset = 0;

    void Start() {
        speed = 12;
        lifeTime = 0.3f;
        hits = 99;

        player = GameObject.FindWithTag("Player");
    }

    new void Move(float deltaTime) {
        transform.position = player.transform.position;
    }

    new void Update() {
        Move(Time.deltaTime);
        base.Update();
    }
}
