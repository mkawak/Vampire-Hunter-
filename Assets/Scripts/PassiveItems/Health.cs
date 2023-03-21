using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Item
{
    public void Start() {
        value = 100;
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
                value += 100;
                AddToPlayer();
                break;
            case 3:
                value += 100;
                AddToPlayer();
                break;
        }
        RemoveFromPlayer(prevVal);
    }
}
