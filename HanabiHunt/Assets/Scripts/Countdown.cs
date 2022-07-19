using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] private float CountdownDuration = 20;
    [SerializeField] private float TimeRemaining;

    public LoadingBar LoadingBar;

    private void Start()
    {
        TimeRemaining = CountdownDuration;
        LoadingBar.FillTime = CountdownDuration;
    }

    public void RestartCountdown()
    {
        TimeRemaining = CountdownDuration;
    }

    private void Update()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
        }
        else
        {
            TimeRemaining = CountdownDuration;
            LoadingBar.FillTime = CountdownDuration;
            //Game Over
        }
    }
}