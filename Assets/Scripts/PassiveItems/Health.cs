using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Item
{
    void Start() {
        value = 20;
    }

    protected virtual void AddToPlayer() {
        player.ChangeHealth(value);
    }

    protected virtual void RemoveFromPlayer(float prevVal) {
        player.ChangeHealth(-prevVal);
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
