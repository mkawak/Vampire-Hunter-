using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Item
{
    void Start() {
        value = 200;
        base.Start();
    }

    protected override void AddToPlayer() {
        player.ChangeHealth(value);
    }

    protected override void RemoveFromPlayer(float prevVal) {
        player.ChangeHealth(-prevVal);
    }

    protected override void ChangeStats() {
        level += 1;
        float prevVal = value;
        switch(level) {
            case 2:
                value += 5;
                AddToPlayer();
                break;
            case 3:
                value += 5;
                AddToPlayer();
                break;
        }
        RemoveFromPlayer(prevVal);
    }
}
