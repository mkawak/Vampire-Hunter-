using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public PlayerCharacter player;

    protected int level = 1;
    protected float value;

    public Sprite image;

    protected void Start() {
        AddToPlayer();
    }

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
        ChangeStats();
    }

    protected virtual void ChangeStats() {
        return;
    }
}
