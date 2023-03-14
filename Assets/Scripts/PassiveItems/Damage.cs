using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Item
{
    void Start() {
        value = 3;
        base.Start();
    }

    protected override void AddToPlayer() {
        player.ChangeDamage(value);
    }

    protected override void RemoveFromPlayer(float prevVal) {
        player.ChangeDamage(-prevVal);
    }

    protected override void ChangeStats() {
        level += 1;
        float prevVal = value;
        switch(level) {
            case 2:
                value += 2;
                AddToPlayer();
                break;
            case 3:
                value += 2;
                AddToPlayer();
                break;
        }
        RemoveFromPlayer(prevVal);
    }
}
