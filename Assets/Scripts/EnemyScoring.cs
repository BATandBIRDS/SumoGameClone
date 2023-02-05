using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScoring : MonoBehaviour
{
    /// <summary>
    /// 
    ///  EnemyScoring.cs has differed from Scoring.cs Because,
    ///   Designer may adjust different rules To Prevent,
    ///    the corruption of justiful scoring(!) May Caused By,
    ///     Increasing || decreasing enemy amounth.
    ///                                         -Savran
    /// 
    /// </summary>

    [HideInInspector] public int enemyScore;
    EnemyAI ai;


    [SerializeField] int enemysDiamondValue = 100;

    void Start()
    {
        ResetScore();
        ai = FindObjectOfType<EnemyAI>();
    }

    void ResetScore()
    {
        enemyScore = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            Destroy(other.gameObject);
            ai.Look();
            ai.FindAndLook();
            enemyScore += enemysDiamondValue;
        }
    }
}
