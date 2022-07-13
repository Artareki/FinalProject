using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownDelegate : MonoBehaviour
{
    public Text CountdownText;
    public float CountdownDuration = 5;
    public float TimeRemaining;

    public delegate void TimesUp();

    public TimesUp OnTimesUp;

    private void Start()
    {
        StartCoroutine(CountdownCoroutine());
        TimeRemaining = CountdownDuration;
    }

    public IEnumerator CountdownCoroutine()
    {
        while (TimeRemaining > 0)
        {
            yield return null;
            TimeRemaining -= Time.deltaTime;
            CountdownText.text = TimeRemaining.ToString("0.00");
        }
        if (OnTimesUp != null)
        {
            OnTimesUp();
        }
    }
}