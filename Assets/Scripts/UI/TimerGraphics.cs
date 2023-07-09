using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerGraphics : MonoBehaviour
{
    public event Action OnTimerExpired;
    
    [SerializeField] private int startingSeconds;
    [SerializeField] private TextMeshProUGUI countdownLabel;

    private void Awake()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        var wait1s = new WaitForSeconds(1.6f);
        int remainingSeconds = startingSeconds;

        while (remainingSeconds > 0)
        {
            countdownLabel.text = remainingSeconds.ToString();
            yield return wait1s;
            remainingSeconds--;
        }

        OnTimerExpired?.Invoke();
    }
}
