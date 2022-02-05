using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    bool stopwatchActive = false;
    float currentTime;
    public Text currentTimeText;
    bool isdown = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        controllercommand1.ResetTimer += ResetTimer;    
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive)
            currentTime = currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartOrStop() {
        stopwatchActive = !stopwatchActive;
    }

    public void IsDown() {
        isdown = true;
    }

    public void ResetTimer() {
        currentTime = 0;
        isdown = false;
    }
}

