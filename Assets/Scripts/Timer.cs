using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TMP_Text textTimer;
    public TEST_GameManager gm;

    private float timer = 0.0f;
    private bool isTimer = false;

    protected float levelTime = 180;

    void Awake()
    {
        StartTimer();
    }


    int diffRef;
    void Start() {
        diffRef = (int)levelTime / 4;
    }
    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }

        if (timer > levelTime) {
            gm.Win();
        }

        if (timer > diffRef) {
            diffRef += 10;
            gm.IncreaseDifficulty();
        }
    }

    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isTimer = true;
    }


    public void StopTimer()
    {
        isTimer = false;
    }

    public void ResetTimer()
    {
        timer = 0.0f; 
    }
}
