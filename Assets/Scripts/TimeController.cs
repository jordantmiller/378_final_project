using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public Rigidbody2D player;
    public TextMeshProUGUI timerText;
    private float timer;
    private bool started;

    void Start()
    {
        timer = 0f;
        started = false;
    }

    void Update()
    {
        if (started) {
            timer += Time.deltaTime;
            updateTimer();
        }
    }

    private void updateTimer() {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        int miliseconds = Mathf.FloorToInt((timer * 1000f) % 1000f);

        timerText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }

    public void StartTimer() {
        started = true;
    }

    public void StopTimer() {
        started = false;
    }
}
