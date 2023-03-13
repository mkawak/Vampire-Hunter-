using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Item
{
    void Start() {
        value = 50;
        base.Start();
    }

    protected override void AddToPlayer() {
        player.ChangeSpeed(value);
    }

    protected override void RemoveFromPlayer(float prevVal) {
        player.ChangeSpeed(-prevVal);
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
