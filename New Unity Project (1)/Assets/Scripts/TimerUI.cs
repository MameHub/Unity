using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private float timeLeft = 10f;

    private void Update()
    {
        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0f)
            {
                Debug.Log("Se acabó el tiempo.");
                timeLeft = 0f;
            }
            timerText.text = timeLeft.ToString();
        }
    }
}

