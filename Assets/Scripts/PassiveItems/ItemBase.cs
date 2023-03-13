using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public PlayerCharacter player;

    protected int level;
    protected float value;

    public Sprite image;

    public int GetLevel() {
        return level;
    }

    protected virtual void AddToPlayer() {
        return;
    }

    protected virtual void RemoveFromPlayer(float prevVal) {
        return;
    }

    public void LevelUp() {
        level += 1;
        ChangeStats();
    }

    protected virtual void ChangeStats() {
        return;
    }
}
