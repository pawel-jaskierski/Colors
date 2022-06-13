using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CLR.Gameplay;
using CLR.UI;
namespace CLR.TimeMenagmnet{
[System.Serializable]
public class TimeMenager {
    [SerializeField]private GameView gameView;
    [SerializeField]private float baseTimeForAnswer;
    private float timeForAnswer;
    private float lastAnswerTime = 0;
    [SerializeField]private Color[] timeIndicatorColors;
    [SerializeField]private float flashTime;
    private UnityAction onLose;
    public void UpdateTimeIndicator(){
        float time = Time.time - lastAnswerTime;
        if(timeForAnswer < time){
            onLose.Invoke();
        }
        else if(time > timeForAnswer*0.7){
            gameView.Flash(timeIndicatorColors[3], timeIndicatorColors[4],flashTime);
        }
        else if(time > timeForAnswer * 0.5f){
            gameView.ChangeTimeColor(timeIndicatorColors[3]);
        }
        else if(time > timeForAnswer * 0.3f){
            gameView.ChangeTimeColor(timeIndicatorColors[2]);
        }
        else if(time > timeForAnswer*0.15f){
            gameView.ChangeTimeColor(timeIndicatorColors[1]);
        }
        
    }
    public void OnButonHit(){
        lastAnswerTime = Time.time;
        gameView.ChangeTimeColor(timeIndicatorColors[0]);
        if(timeForAnswer>baseTimeForAnswer/4) timeForAnswer -= 0.15f;
        Debug.Log(timeForAnswer);
        
        

    }
    public void SetOnLose(UnityAction onLose){
        this.onLose = onLose; 
    }
    public void Init(){
        lastAnswerTime = Time.time;
        timeForAnswer = baseTimeForAnswer;
    }

}
    
}
