using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    int currentScore = 10;

    public void IncreaseScore(int score){
        currentScore += score;
    }

    public void DecreaseScore(int score){
        currentScore -= score;
    } 

    public int GetScore(){
        int OutputScore = currentScore;
        currentScore = 10;
        return OutputScore;
    }

}