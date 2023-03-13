using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Item
{
    void Start() {
        value = 3;
    }

    protected virtual void AddToPlayer() {
        player.ChangeDamage(value);
    }

    protected virtual void RemoveFromPlayer(float prevVal) {
        player.ChangeDamage(-prevVal);
    }

    protected virtual void ChangeStats() {
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
