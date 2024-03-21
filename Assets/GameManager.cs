using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score=0;
    private void Update()
    {
        scoreText.text=score.ToString();
    }
    public void ScoreUpdate(int ScoreIncrement)
    {
        score =+ ScoreIncrement;
    }
}
