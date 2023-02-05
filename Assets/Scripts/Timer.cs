using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float gameDuration = 20f;

    [HideInInspector] public float fillFraction;
    [HideInInspector] public bool isGameOn;
    [HideInInspector] public bool timesUpWin = false;
    float timerValue;

    Scoring ps;
    EnemyScoring es;

    void Awake()
    {
        ps = FindObjectOfType<Scoring>();
        es = FindObjectOfType<EnemyScoring>();
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isGameOn)
        {
            // when we still have time
            if (timerValue > 0)
            {
                fillFraction = timerValue / gameDuration; // mid-top pie-timer
                timesUpWin = false;
            }

            // When Time is UP
            else
            {
                // Decides who is the winner if times up
                if (ps.playerScore > es.enemyScore) { timesUpWin = true; }
                else { timesUpWin = false; }
                timerValue = gameDuration;
            }
        }       
    }
}