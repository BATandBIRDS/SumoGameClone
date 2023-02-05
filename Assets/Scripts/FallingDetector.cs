using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FallingDetector : MonoBehaviour
{
    /// <summary>
    /// 
    ///  This script detects fallen enemies and,
    ///   if player falls.
    ///   
    ///   Also, Adjusts some UI and,
    ///   Responsible for WIN-FAIL MECHANICS.
    ///   
    ///   Partners: Scoring.cs, Timer.cs, EnemyScoring.cs
    /// 
    /// </summary>

    [HideInInspector] public int fallenEnemies = 0;

    [SerializeField] int totalEnemyAmount = 6;
    [SerializeField] ParticleSystem winEffect;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] TextMeshProUGUI fallenEnemiesTxt;
    [SerializeField] float nextGameLoadTime = .2f;

    Timer timer;

    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        timer.isGameOn = true;
    }

    void Update()
    {
        //mid-top pie-timer
        timerImage.fillAmount = timer.fillFraction;

        //Right text with X showing how many enemy falled.
        fallenEnemiesTxt.text = fallenEnemies.ToString() + "X";

        if (!timer.isGameOn)
        {
            Invoke("ReloadScene", nextGameLoadTime);
        }
        if (timer.timesUpWin)
        {
            winEffect.Play();
        }
    }

    void ReloadScene()
    {
        fallenEnemies = 0; // resets UI
        timer.isGameOn = true;
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter(Collider other)
    {
        // Fallen Enemy Counter
        if (other.tag == "Enemy")
        {
            fallenEnemies += 1;

            //destroying fallen enemy for optimization purposes
            Destroy(other.gameObject);
            
            // WIN condition
            if (fallenEnemies == totalEnemyAmount)
            {
                winEffect.Play();
                timer.isGameOn = false;
            }
        }

        // FAIL condition
        else if (other.tag == "Player")
        {
            timer.isGameOn = false;
        }
    }



}

    
