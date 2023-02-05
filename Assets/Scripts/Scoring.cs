using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [HideInInspector] public int playerScore;

    FallingDetector fd;
    EnemyAI ai;

    [SerializeField] int diamondValue = 100;
    [SerializeField] TextMeshProUGUI playerScoreTxt;

    void Awake()
    {
        fd = FindObjectOfType<FallingDetector>();
        ai = FindObjectOfType<EnemyAI>();
    }
    void Start()
    {
        ResetScore();
    }
    void Update()
    {
        playerScoreTxt.text = playerScore.ToString(); // Left UI
    }

    void ResetScore()
    {
        playerScore = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Diamond")
        {
            // if player disqualifies an enemy, diamonds become more valuable
            // the reason is this is not a multiplayer game.
            // so, there is just one enemy which is CPU.

            // +1 is for prevent multiplying with zero
            playerScore += diamondValue * (fd.fallenEnemies + 1);
            Destroy(other.gameObject);
            ai.diamonds.Remove(other.transform);
        }
    }     
}