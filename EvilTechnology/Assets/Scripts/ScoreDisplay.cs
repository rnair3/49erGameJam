using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    float timer;
    TextMeshProUGUI scoreDisplay;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        scoreDisplay = GetComponent<TextMeshProUGUI>();
        scoreDisplay.text = gameSession.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f && FindObjectOfType<Player>() != null)
        {
            gameSession.AddScore(1);
            scoreDisplay.text = gameSession.GetScore().ToString();
            timer = 0;
        }
        
    }
}
