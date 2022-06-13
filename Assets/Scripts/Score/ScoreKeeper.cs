using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CLR.Score{
    public class ScoreKeeper{
        private int score = 0;
        private int highScore = 0;
        public int Score() => score;
        public int HighScore() => highScore;

        public void IncreaseScore(){
            score++;
            Debug.Log("Hi");
        }

        public void Reset(){
            score = 0;
        }
        public void Init(){
            if(PlayerPrefs.HasKey("highScore")) highScore =  PlayerPrefs.GetInt("highScore");
            else PlayerPrefs.SetInt("highScore",0);
        }
        public void SetHighScore(){
            if(highScore < score){
                highScore = score;
                PlayerPrefs.SetInt("highScore",score);
            }
            Debug.Log(highScore);

        }
    }

}

