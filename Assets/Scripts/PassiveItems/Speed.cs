using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Item
{
    void Start() {
        value = 10;
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
                value += 10;
                AddToPlayer();
                break;
            case 3:
                value += 10;
                AddToPlayer();
                break;
        }
        RemoveFromPlayer(prevVal);
    }
}
